CREATE STREAM input_stream_raw (
  id STRING,
  type STRING,
  payload STRING
) WITH (
  KAFKA_TOPIC='topic_input',
  VALUE_FORMAT='JSON',
  PARTITIONS=1
);

CREATE STREAM stream_type_a WITH (KAFKA_TOPIC='topic_type_a') AS
SELECT * FROM input_stream_raw
WHERE type = 'A';

CREATE STREAM stream_type_b WITH (KAFKA_TOPIC='topic_type_b') AS
SELECT * FROM input_stream_raw
WHERE type = 'B';

