for i in `find /home/database/ -name "*.sql" | sort --version-sort`; do mysql -udocker -pdocker mjv_marketplace < $i; done;
