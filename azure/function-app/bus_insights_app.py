import os
import json
import pandas as pd
import datetime
import requests

postreqdata = json.loads(open(os.environ['req']).read())


routes = pd.read_csv('./data/routes_filtered.csv')
trips = pd.read_csv('./data/trips_filtered.csv')
stop_times = pd.read_csv('./data/stop_times_filtered.csv')
stops = pd.read_csv('./data/stops_filtered.csv')
stop_times['time'] = pd.to_datetime(stop_times['arrival_time'], format='%H:%M:%S').dt.time

central_stops = stops.loc[stops.stop_name.str.contains('Eddy')].stop_id.unique()
stop_times = stop_times.loc[stop_times.stop_id.isin(central_stops)]

cur_time = datetime.datetime.strptime(postreqdata['cur_time'],"%H:%M:%S")
max_time = cur_time + datetime.timedelta(minutes = 11)
result = stop_times.loc[(stop_times.stop_id.isin(central_stops)) & 
                        (stop_times.time > cur_time.time()) & 
                        (stop_times.time <= max_time.time())]
result = result.sort_values('time')
result = result.drop(['time'], axis=1)
result = pd.merge(result, trips, how='left', left_on=['trip_id'], right_on=['trip_id'])

# Make requests to ML, get predictions, merge predictions
minutes = str(cur_time.hour * 60 + cur_time.minute)
day = str(postreqdata['day'])

config = {
    'congestion_level': {
        'url': 'https://ussouthcentral.services.azureml.net/workspaces/b6632165c56549428ba5b91dea891b3c/services/adabec3659694d2183ad02fc107ea264/execute?api-version=2.0&details=true',
        'api_key': 'kn0eAb90cUG7UFZ8faN+ox350JqR2+NzoEACJMhh4/Exmh+NiH8uxCwUrwL58wt6A77TYF3KcLespJnlFxQv5A=='
    },
    'occupancy_status': {
        'url': 'https://ussouthcentral.services.azureml.net/workspaces/b6632165c56549428ba5b91dea891b3c/services/9d258dddc5ad4d56a4c497e7db9ade1f/execute?api-version=2.0&details=true',
        'api_key': '3PIiQizHEFXCSkJ/VGBpc9YX1v0svRVfUvuSNmPs+2pusx15dhuOkwN6rHwtppf2SBPB2zdOe7XRYYAaoahhFw=='
    }
}

for pred_column in ['congestion_level', 'occupancy_status']:
    # Make values list
    req_df = result[['stop_id', 'trip_id']]
    req_df['minutes'] = minutes
    req_df['day'] = day
    req_df[pred_column] = '0'
    columns = ['stop_id', 'trip_id', 'minutes', 'day', pred_column]
    for col in columns:
        req_df[col] = req_df[col].apply(str)
    values = req_df.to_dict('split')['data']
    # Make ML req for pred_column
    url = config[pred_column]['url']
    api_key = config[pred_column]['api_key']
    headers = {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer {}'.format(api_key)
    }
    data = {
        "Inputs": {
            "input": {
                "ColumnNames": [
                    "stop_id",
                    "trip_id",
                    "minutes",
                    "day",
                    pred_column
                ],
                "Values": values
            }
        },
        "GlobalParameters": {}
    }
    r = requests.post(url, headers=headers, data=json.dumps(data))
    pred_res = r.json()
    output_values = pred_res['Results']['output']['value']['Values']
    output_pred = [item[-1] for item in output_values]
    print('------------------- Completing prediction for:', pred_column)
    result[pred_column] = output_pred

# Make ML req for occu

# Merge res values for both

response = open(os.environ['res'], 'w')
result_dict = result.to_dict('records')
res_json = json.dumps(result_dict)
response.write(res_json)
response.close()
