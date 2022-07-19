# DADS6005
We already install cloudera docker

#start clouder docker </br>

> sudo su - </br>
<!--
https://docs.cloudera.com/documentation/enterprise/6/6.3/topics/cdh_ports.html
docker run --hostname=quickstart.cloudera --privileged=true -t -i -p 8888:8888 -p 7180:7180 -p 80:80 4239cd2958c6 /usr/bin/docker-quickstart </br>

docker run --hostname=quickstart.cloudera --privileged=true -t -i -p 8888:8888 -p 10000:10000 -p 10020:10020 -p 11000:11000 -p 18080:18080 -p 18081:18081 
-p 18088:18088 -p 19888:19888 -p 21000:21000 -p 21050:21050 -p 2181:2181 -p 25000:25000 -p 25010:25010 -p 25020:25020 -p 50010:50010 -p 50030:50030 -p 50060:50060 
-p 50070:50070 -p 50075:50075 -p 50090:50090 -p 60000:60000 -p 60010:60010 -p 60020:60020 -p 60030:60030 -p 7180:7180 -p 7183:7183 -p 7187:7187 -p 80:80 
-p 8020:8020 -p 8032:8032 -p 802:8042 -p 8088:8088 -p 8983:8983 -p 9083:9083 4239cd2958c6 /usr/bin/docker-quickstart

-->
> docker run -v /root:/mnt --hostname=quickstart.cloudera --privileged=true -t -i -p 9092 -p 2181 -p 11123 cloudera/quickstart /usr/bin/docker-quickstart </br>

[root@quickstart]# cd /mnt
[root@quickstart mnt]# hadoop fs -mkdir -p /home/cloudera/data
[root@quickstart mnt]# hadoop fs -put test.txt /home/cloudera/data/test.txt

[root@quickstart mnt]# hadoop jar /usr/lib/hadoop-mapreduce/hadoop-streaming.jar 
-input /home/cloudera/data/test.txt 
-output /home/cloudera/data/wc 
-mapper 'python mapper.py' 
-reducer 'python reducer.py' 
-file mapper.py 
-file reducer.py

[root@quickstart mnt]# hadoop fs -cat /home/cloudera/data/wc/part-00000


