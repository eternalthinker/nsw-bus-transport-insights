select arrival_time, stop_sequence, stop_id, route_id, trips.trip_id, trip_headsign, route_direction from stop_times, trips
where 
	stop_times.stop_id in ('200039', '200053', '200054') and
	time(arrival_time) > time('08:09:00') and
	time(arrival_time) < time('08:19:00') and
	stop_times.trip_id = trips.trip_id
order by time(arrival_time) limit 10
;