curl 
	'https://studioapi.azureml.net/api/workspaces/b6632165c56549428ba5b91dea891b3c/webservicegroups/79b950cd8db546d09465efeca0e9f9c1/webservices/4aea49e6a8e84b78b83049e971a30e60/score' 
	-H 'x-ms-client-session-id: ead934b3-a22d-44bb-897d-24d1cb9d5211' 
	-H 'Origin: https://studio.azureml.net' 
	-H 'Accept-Encoding: gzip, deflate, br' 
	-H 'Accept-Language: en-US,en;q=0.9' 
	-H 'x-ms-client-user-type: UxUser' 
	-H 'x-ms-client-subscription-id: null' 
	-H 'DataLabAccessToken: eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImlCY1dEa2M3Tlc1SEhSNnlSczR6UEFfOUZiOCJ9.eyJ1bmlxdWVfbmFtZSI6IlJhaHVsIEFuYW5kIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS9hY2Nlc3Njb250cm9sc2VydmljZS8yMDEwLzA3L2NsYWltcy9pZGVudGl0eXByb3ZpZGVyIjoiQUFEIiwiYXV0aG9yX2lkIjoiQjk1MjY2QjY3MkU1RkNBQUFFM0NCMTE3Qjc5Nzc2QjNFQkVENzZFOEE4MzBFQUUxNEY5MjQ2ODQwQzhCREMwRiIsImVtYWlsIjoiejUxNTI0MDZAYWQudW5zdy5lZHUuYXUiLCJuYW1laWQiOiIxMDAzM0ZGRjlEMDJGOTZBIiwidGlkIjoiM2ZmNmNmYTQtZTcxNS00OGRiLWI4ZTEtMDg2N2I5ZjlmYmEzIiwicm9sZSI6Ik93bmVyIiwiaHR0cDovL3NjaGVtYXMuYXp1cmVtbC5uZXQvd3MvMjAxNC8xMS9pZGVudGl0eS9jbGFpbXMvV29ya3NwYWNlSWQiOiJiNjYzMjE2NWM1NjU0OTQyOGJhNWI5MWRlYTg5MWIzYyIsImh0dHA6Ly9zY2hlbWFzLmF6dXJlbWwubmV0L3dzLzIwMTQvMTEvaWRlbnRpdHkvY2xhaW1zL1dvcmtzcGFjZVR5cGUiOlsiRnJlZSIsIkZyZWUiXSwicmVnaW9uIjoiU291dGggQ2VudHJhbCBVUyIsImh0dHA6Ly9zY2hlbWFzLmF6dXJlbWwubmV0L3dzLzIwMTQvMTEvaWRlbnRpdHkvY2xhaW1zL0RhdGFzZXQiOiIyMTQ3NDgzNjQ4IiwiaHR0cDovL3NjaGVtYXMuYXp1cmVtbC5uZXQvd3MvMjAxNC8xMS9pZGVudGl0eS9jbGFpbXMvV2ViU2VydmljZXMiOiJTdGFnaW5nIiwiaXNzIjoiTUFNTFNUUyIsImF1ZCI6Imh0dHBzOi8vc3R1ZGlvLmF6dXJlbWwubmV0LyIsImV4cCI6MTUyNjQ1NTQzMywibmJmIjoxNTI2NDI2NjMzfQ.QY3BYWwYHs5-bnSbhcnhGC_M7BDMMaM3azPS6sn_0T73TmazUo4N9x-eS0XaVxUolqQepK5LGoHGjbT0fDPFvG64ub2Jy6suAPf-5df-1zn5FOL65Sxtj0zaFgNW6PVe2nrxygE9p6nm3QnQzF_7JoGc0ORrVrPN6AD7hRDVpiOfh1zynkGQ927nzsWaF2psyjPJ0Zc88iW9EHnvUuVOJaVY7VRNFwsaUDq5cBGN0Mv9hG6OyzMuAzqfHG_QkeswFMbZN_Dnfs_stNZSoJ-LRHlEukm8zhApbOcbk5IzPN8zyIQXoIfcmrkBmLMdTEdHU9UXse280zsmH50atDXltQ' 
	-H 'x-ms-client-request-id: 9f5cf871-7781-400b-902d-cf075b726774' 
	-H 'Connection: keep-alive' 
	-H 'User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.170 Safari/537.36' 
	-H 'Content-Type: application/json;charset=UTF-8' 
	-H 'Accept: */*' 
	-H 'x-ms-client-workspace-id: b6632165c56549428ba5b91dea891b3c' 
	-H 'Referer: https://studio.azureml.net/Home/ViewWorkspaceCached/b6632165c56549428ba5b91dea891b3c' 
	--data-binary '{"Id":"scoring0002","Instance":{"FeatureVector":{"stop_id":"203251","trip_id":"681483","minutes":"1376","day":"3","congestion_level":"4"},"GlobalParameters":{}}}' --compressed ;

{
  "Id":"scoring0002",
  "Instance":{
    "FeatureVector":{
      "stop_id":"203251",
      "trip_id":"681483",
      "minutes":"1376",
      "day":"3",
      "congestion_level":"4"
    },
    "GlobalParameters":{

    }
  }
}