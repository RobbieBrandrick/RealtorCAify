Root=/usr/bin/RealtorCAify
DeployToLocation=$Root/bin

echo "Updating Container and adding required programs"
apt update
apt -y install nano wget curl zip nginx

wget https://dot.net/v1/dotnet-install.sh
bash ./dotnet-install.sh -c Current -version latest --install-dir /usr/share/dotnet  --runtime dotnet

echo "Unzipping Deployment"
mkdir $Root
mkdir $DeployToLocation
unzip -q /Deployment.zip -d $DeployToLocation/

mv $DeployToLocation/CrontabEntry $Root
mv $DeployToLocation/CrontabProcess.sh $Root

crontab $Root/CrontabEntry
