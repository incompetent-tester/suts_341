<pre><i>Windows Specific Instructions </i></pre>

<h1> Mysql Running Multiple Instances </h1>

1. Look into the server1 + server2 folder.

2. To regenerate database run the "init_data.bat". 

3. Modify "my.ini". Ensure the listening port differs from the original. Ensure points to the correct directory.

4. Run multiple instance of mysql with command 

<i>Instance 1:</i>
<code>
mysqld --defaults-file="C:\database\server1\my.ini" --standalone --console
</code>
<br/>
<i>Instance 2:</i>
<code>
mysqld --defaults-file="C:\database\server2\my.ini" --standalone --console
</code>
<br/>

4. a Add "server_id=1" to first instance's my.ini file
4. b Add "log-bin="C://database/server1/log/server1-bin.log" to first instance's my.ini file
4. c Add "server_id=2" to second instance's my.ini file


5. Execute on Instance 1:
<br/>
<pre>
create user 'replicator'@'%' IDENTIFIED WITH mysql_native_password BY 'PASSWORD';

GRANT REPLICATION SLAVE ON *.* TO 'replicator'@'%';
 FLUSH PRIVILEGES;
</pre>
<br/>
5. a Execute "show master status". Take note of "log_pos" column. Let's call it variable "XXX"

6. Execute on Instance 2:

<pre>
stop slave;
CHANGE MASTER TO MASTER_HOST = '127.0.0.1', 
MASTER_PORT = 3307,
MASTER_USER = 'replicator', 
MASTER_PASSWORD = 'PASSWORD', 
MASTER_LOG_POS = XXX <---- insert "XXX" here
MASTER_LOG_FILE = 'server1-bin.000002';
start slave;
</pre>
<br/>

<h1> Mongodb Running Multiple Instances </h1>
1. Execute multiple instances as replication set

<pre>
mongod --dbpath="./db1" --replSet rs0 --port 27017 # Instance 1

mongod --dbpath="./db2" --replSet rs0 --port 27018 # Instance 2
</pre>

2. Initiate replication

<pre>
rs.initiate( {
   _id : "rs0",
   members: [
      { _id: 0, host: "localhost:27017" },
      { _id: 1, host: "localhost:27018" },

   ]
})
</pre>

