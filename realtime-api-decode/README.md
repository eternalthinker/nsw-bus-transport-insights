
# Generate python code for GTFS protobuf definition

./protoc-3.5.1-linux-x86_64/bin/protoc --proto_path=gtfs --python_out=gen gtfs/gtfs-realtime.proto


# Add required python libraries

`cd realtime-api-code` 
`virtualenv -p python3 venv`
`source venv/bin/activate`
`pip install -r requirements.txt`


# Run script
* mkdir download
* Add your API key in secret.py
* python decode_api.py
* Updated files are downloaded to download/ directory
