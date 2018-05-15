 create table bus_updates (
     id int not null primary key auto_increment,
         stop_id varchar(25),
         arrival_timestamp varchar(25),
         vehicle_id varchar(50),
          congestion_level int(2) ,
          longitude varchar(50),
          latitude varchar(50),
          trip_id varchar(25),
          occupancy_status int(2),
          route_id varchar(25),
          delay varchar(25),
          timestamp varchar(25)
      );

 create table stops (
 	stop_id varchar(25),
 	stop_name varchar(100),
 	stop_lat varchar(25),
 	stop_lon varchar(25),
 	location_type varchar(25),
 	parent_station varchar(25),
 	wheelchair_boarding varchar(10)
 );



create table trips (
	route_id  varchar(25),
	service_id  varchar(25),
	trip_id  varchar(25),
	shape_id varchar(25),
	trip_headsign varchar(25),
	direction_id varchar(25),
	block_id varchar(25),
	wheelchair_accessible varchar(25),
	trip_note varchar(25),
	route_direction  varchar(100)
);

create table routes (
	route_id varchar(25),
agency_id varchar(25),
route_short_name varchar(100),
route_long_name varchar(100),
route_desc varchar(25),
route_type varchar(25),
route_color varchar(25),
route_text_color varchar(25)
);

create table stop_times (
	trip_id varchar(25),
arrival_time time,
departure_time time,
stop_id varchar(25),
stop_sequence varchar(25),
stop_headsign varchar(25),
pickup_type varchar(25),
drop_off_type varchar(25),
shape_dist_traveled varchar(25),
timepoint varchar(25),
stop_note varchar(25)
);

