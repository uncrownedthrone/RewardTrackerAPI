docker build -t reward-tracker-api-image .

docker tag reward-tracker-api-image registry.heroku.com/reward-tracker-api/web

docker push registry.heroku.com/reward-tracker-api/web

heroku container:release web -a reward-tracker-api