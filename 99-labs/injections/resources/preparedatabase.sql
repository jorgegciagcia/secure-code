-- Create database
CREATE DATABASE test;
-- switch database
\c test
-- Crate table
CREATE TABLE IF NOT EXISTS users (
  id SERIAL,
  username VARCHAR(50) NOT NULL,
  password VARCHAR(50) NOT NULL,
  moreinfo VARCHAR(2000),
  PRIMARY KEY (id)
);

-- Fill table users
INSERT INTO users (username, password)
SELECT 
  'user' || i AS username, 
  md5(random()::text) AS password
FROM generate_series(1, 10) AS s(i);
