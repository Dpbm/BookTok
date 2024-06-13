#!/bin/sh
set -e
BASE_URL="http://localhost:3000/api"

PURPLE='\033[0;35m'
RESET_COLOR='\033[0m'

echo "$PURPLE---INSERT TEST---$RESET_COLOR"
curl -f --show-error -v -s \
     --header "Content-Type: application/json" \
     --request POST \
     --data '{"Id":1,"ReviewText":"Very good book!","Rating":5,"Date":1718192018625,"CostumerId":1,"BookId":10}' \
     "$BASE_URL/Reviews" | jq

echo ""
echo "$PURPLE---GET ALL TEST---$RESET_COLOR"
curl -f --show-error -v -s "$BASE_URL/Reviews" | jq

echo ""
echo "$PURPLE---GET ALL BASED ON BOOK ID TEST---$RESET_COLOR"
curl -f --show-error -v -s "$BASE_URL/Reviews/Book/10" | jq

echo ""
echo "$PURPLE---GET BY ID TEST---$RESET_COLOR"
curl -f --show-error -v -s "$BASE_URL/Reviews/1" | jq

echo ""
echo "$PURPLE---UPDATE TEST---$RESET_COLOR"
curl -f --show-error -v -s \
     --header "Content-Type: application/json" \
     --request PUT \
     --data '{"Id":1,"ReviewText":"Very good book, However, it is too short!","Rating":3,"Date":1718192365172,"CostumerId":1}' \
     "$BASE_URL/Reviews/1" | grep HTTP

echo ""
echo "$PURPLE---GET BY ID AFTER UPDATE---$RESET_COLOR"
curl -f --show-error -v -s "$BASE_URL/Reviews/1" | jq

echo ""
echo "$PURPLE---DELETE TEST---$RESET_COLOR"
curl -f --show-error -v -s \
     --request DELETE \
     "$BASE_URL/Reviews/1" | jq

echo ""
echo "$PURPLE---GET ALL AFTER DELETION---$RESET_COLOR"
curl -f --show-error -v -s "$BASE_URL/Reviews" | jq
