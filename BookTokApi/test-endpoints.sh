#!/bin/sh

if [ -z $1 ]; then
    echo "You must provide the base URL for your api!"
    exit 1
fi

BASE_URL="$1/api"

PURPLE='\033[0;35m'
RESET_COLOR='\033[0m'

echo "$PURPLE---INSERT TEST---$RESET_COLOR"
curl -v -s \
     --header "Content-Type: application/json" \
     --request POST \
     --data '{"Id":1,"ReviewText":"Very good book!","Rating":5,"Date":1718192018625,"CostumerId":1}' \
     "$BASE_URL/Reviews" | jq

echo ""
echo "$PURPLE---GET ALL TEST---$RESET_COLOR"
curl -v -s "$BASE_URL/Reviews" | jq

echo ""
echo "$PURPLE---GET BY ID TEST---$RESET_COLOR"
curl -v -s "$BASE_URL/Reviews/1" | jq

echo ""
echo "$PURPLE---UPDATE TEST---$RESET_COLOR"
curl -v -s \
     --header "Content-Type: application/json" \
     --request PUT \
     --data '{"Id":1,"ReviewText":"Very good book, However, it is too short!","Rating":3,"Date":1718192365172,"CostumerId":1}' \
     "$BASE_URL/Reviews/1" | grep HTTP

echo ""
echo "$PURPLE---GET BY ID AFTER UPDATE---$RESET_COLOR"
curl -v -s "$BASE_URL/Reviews/1" | jq

echo ""
echo "$PURPLE---DELETE TEST---$RESET_COLOR"
curl -v -s \
     --request DELETE \
     "$BASE_URL/Reviews/1" | jq

echo ""
echo "$PURPLE---GET ALL AFTER DELETION---$RESET_COLOR"
curl -v -s "$BASE_URL/Reviews" | jq

