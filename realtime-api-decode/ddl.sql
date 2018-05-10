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