
# Generate python code for GTFS protobuf definition (already present in gen/ directory)

`./protoc-3.5.1-linux-x86_64/bin/protoc --proto_path=gtfs --python_out=gen gtfs/gtfs-realtime.proto`


# Add required python libraries

1. `cd realtime-api-code`  
2. `virtualenv -p python3 venv`  
3. `source venv/bin/activate`  
4. `pip install -r requirements.txt`   


# Run script
1. `mkdir download`
2. Add your API key in `secret.py`   
3. `python decode_api.py`   
4. Updated files are downloaded to `download/` directory  
