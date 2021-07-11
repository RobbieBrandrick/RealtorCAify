root=/home/notyours/Storage/dev/RealtorCAify/crontab
log=$root/log

echo "Starting ($(date))" >> $log

cd $root/bin/Debug/net5.0  || exit

./RealtorCAify >> $log 2>&1

echo "Ending ($(date))" >> $log