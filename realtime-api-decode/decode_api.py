import requests
from google.transit import gtfs_realtime_pb2
import json

# import gen.gtfs_realtime_pb2 as gtfs
from config import config
from secret import secret

api_key = secret["api_key"]
vehicle_pos_endpoint = config["endpoints"]["vehicle_pos"]["endpoint"]
trip_updates_endpoint = config["endpoints"]["trip_updates"]["endpoint"]
headers = {
	"Authorization": "apikey {}".format(api_key)
}

print("GET veh pos")
vehicle_pos_res = requests.get(vehicle_pos_endpoint, headers=headers)
vehicle_pos_feed = gtfs_realtime_pb2.FeedMessage()
vehicle_pos_feed.ParseFromString(vehicle_pos_res.content)

print("GET trip updt")
trip_updates_res = requests.get(trip_updates_endpoint, headers=headers)
trip_updates_feed = gtfs_realtime_pb2.FeedMessage()
trip_updates_feed.ParseFromString(trip_updates_res.content)

print("Parsing...")

routes = set(config["routes"])

filtered_trip_updates = []
for entity in trip_updates_feed.entity:
	if entity.trip_update.trip.route_id in routes:
		filtered_trip_updates.append(entity.trip_update)

vehicle_infos = []
for entity in vehicle_pos_feed.entity:
	vehicle = entity.vehicle
	route_id = vehicle.trip.route_id
	if route_id not in routes:
		continue
	print("Checking stops for route:", route_id)
	trip_id = vehicle.trip.trip_id
	timestamp = vehicle.timestamp
	trip_update = None
	for trip_u in filtered_trip_updates:
		if trip_u.trip.trip_id == trip_id:
			trip_update = trip_u
			break
	if trip_update is None:
		print("Could not find trip for vehicle")
		continue
	near_stop = None
	num_stops_checked = 0
	for stop in trip_update.stop_time_update:
		stop_arrival_time_delta = abs(stop.arrival.time - timestamp)
		if stop_arrival_time_delta < 60:
			near_stop = stop
			break
		num_stops_checked += 1
		if num_stops_checked == 3:
			break
	if near_stop is None or \
	   near_stop.schedule_relationship != gtfs_realtime_pb2.TripUpdate.StopTimeUpdate.SCHEDULED:
		print("X	No nearby stops found")
		continue
	vehicle_info = {
		"route_id": route_id,
		"trip_id": trip_id,
		"latitude": vehicle.position.latitude,
		"longitude": vehicle.position.longitude,
		"timestamp": timestamp,
		"congestion_level": vehicle.congestion_level,
		"occupancy_status": vehicle.occupancy_status,
		"vehicle_id": vehicle.vehicle.id,
		"stop_id": near_stop.stop_id,
		"delay": near_stop.arrival.delay,
		"arrival_timestamp": near_stop.arrival.time
	}
	vehicle_infos.append(vehicle_info)

print("Rows:", len(vehicle_infos))
with open("download/rows.json", "w") as rows_file:
	json_str = json.dumps(vehicle_infos, indent=4)
	rows_file.write(json_str)

print("Done!")


# vehicle_infos = []
# for entity in vehicle_pos_feed.entity:

# for entry in endpoints:
# 	endpoint = entry["endpoint"]
# 	filename = entry["filename"]
# 	r = requests.get(endpoint, headers=headers)
# 	feedmsg = gtfs.FeedMessage()
# 	feedmsg.ParseFromString(r.content)
# 	save_file_name = "download/{}.txt".format(filename)
# 	save_file = open(save_file_name, "w")
# 	save_file.write(str(feedmsg))
# 	save_file.close()
# 	print("Saved: {}".format(endpoint))
