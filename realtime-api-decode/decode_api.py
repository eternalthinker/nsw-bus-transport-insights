import requests

import gen.gtfs_realtime_pb2 as gtfs
from config import config


api_key = config["api_key"]
endpoints = config["endpoints"]
headers = {
	"Authorization": "apikey {}".format(api_key)
}
for entry in endpoints:
	endpoint = entry["endpoint"]
	filename = entry["filename"]
	r = requests.get(endpoint, headers=headers)
	feedmsg = gtfs.FeedMessage()
	feedmsg.ParseFromString(r.content)
	save_file_name = "download/{}.txt".format(filename)
	save_file = open(save_file_name, "w")
	save_file.write(str(feedmsg))
	save_file.close()
	print("Saved: {}".format(endpoint))
