# FormHost

echo "Killing processes of FormHost databases"

osql -E -S . -d master -i FH_helper_01.sql -n

echo "Cleaning DataBase..."
osql -E -S  . -d FormHost -i 01CleanDB.sql -n

echo "Creating DataBase..."
osql -E -S  . -d FormHost -i 02CreateDB.sql -n

echo "Adding Basedata..."
osql -E -S  . -d FormHost -i 03BaseData.sql -n

