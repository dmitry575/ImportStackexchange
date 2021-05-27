rem docker volume create pgdata
docker-compose -f postgres.yml down
docker-compose -f postgres.yml build db adminer
docker-compose -f postgres.yml up -d
