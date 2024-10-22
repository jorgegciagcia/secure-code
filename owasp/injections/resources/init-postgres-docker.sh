#!/bin/bash

# Ensure the script exits if any command fails
set -e

# Define the source and destination paths
SOURCE_PATH="./preparedatabase.sql"
DESTINATION_PATH="/tmp/preparedatabase.sql"

# Copy the preparedatabase.sql file to the /tmp directory in the Docker container
docker cp "$SOURCE_PATH" postgres:"$DESTINATION_PATH"
echo "File copied successfully to the Docker container's /tmp directory."

# Execute the SQL script inside the Docker container
docker exec postgres  psql -U postgres -d postgres -f "$DESTINATION_PATH"
echo "SQL script executed successfully in the Docker container."