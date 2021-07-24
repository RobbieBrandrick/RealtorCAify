root=/usr/bin/RealtorCAify
log=$root/log

echo "Starting ($(date))" >> $log

cd $root/bin || exit

./RealtorCAify >> $log 2>&1

echo "Ending ($(date))" >> $log