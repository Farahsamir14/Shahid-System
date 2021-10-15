--------------------------------------------------------
--  File created - Wednesday-April-15-2020   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence ACTOR_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "ACTOR_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence EPISODE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "EPISODE_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence GEN_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "GEN_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence MOVIE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "MOVIE_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 81 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence M_GEN_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "M_GEN_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence REV_ID_EP_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "REV_ID_EP_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence REV_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "REV_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence SERIES_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "SERIES_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence S_GEN_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "S_GEN_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence USER_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "USER_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table ACTOR
--------------------------------------------------------

  CREATE TABLE "ACTOR" 
   (	"A_ID" NUMBER, 
	"A_FNAME" VARCHAR2(20), 
	"A_LNAME" VARCHAR2(20), 
	"A_BDATE" DATE, 
	"A_GENDER" VARCHAR2(20)
   ) ;
--------------------------------------------------------
--  DDL for Table ADDS_EPISODE
--------------------------------------------------------

  CREATE TABLE "ADDS_EPISODE" 
   (	"USERID" NUMBER, 
	"EPISODEID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table ADDS_MOVIE
--------------------------------------------------------

  CREATE TABLE "ADDS_MOVIE" 
   (	"USERID" NUMBER, 
	"MOVIEID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table EPISODE
--------------------------------------------------------

  CREATE TABLE "EPISODE" 
   (	"EP_ID" NUMBER, 
	"EP_NUMBER" NUMBER, 
	"EP_SEASON" NUMBER, 
	"EP_LEN" NUMBER, 
	"EP_DATE" DATE, 
	"SERIESID" NUMBER, 
	"EP_IMG" BLOB, 
	"EP_VID" BLOB
   ) ;
--------------------------------------------------------
--  DDL for Table MOVIE
--------------------------------------------------------

  CREATE TABLE "MOVIE" 
   (	"MOV_ID" NUMBER, 
	"MOV_NAME" VARCHAR2(20), 
	"MOV_DESC" VARCHAR2(200), 
	"MOV_RATE" NUMBER, 
	"MOV_LEN" NUMBER, 
	"MOV_LANG" VARCHAR2(20), 
	"MOV_DATE" DATE, 
	"MOV_IMG" BLOB, 
	"MOV_TYPE" VARCHAR2(20), 
	"MOV_VID" BLOB
   ) ;
--------------------------------------------------------
--  DDL for Table MOVIE_ACTED_BY
--------------------------------------------------------

  CREATE TABLE "MOVIE_ACTED_BY" 
   (	"ACTORID" NUMBER, 
	"MOVIEID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table MOVIE_GENRE
--------------------------------------------------------

  CREATE TABLE "MOVIE_GENRE" 
   (	"GEN_ID" NUMBER, 
	"GEN_NAME" VARCHAR2(20), 
	"MOVIEID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table REV_EPISODE
--------------------------------------------------------

  CREATE TABLE "REV_EPISODE" 
   (	"REV_ID" NUMBER, 
	"REV_RATE" NUMBER DEFAULT null, 
	"REV_COMMENT" VARCHAR2(20) DEFAULT null, 
	"REV_DATE" DATE, 
	"USERID" NUMBER, 
	"EPISODEID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table REV_MOVIE
--------------------------------------------------------

  CREATE TABLE "REV_MOVIE" 
   (	"REV_ID" NUMBER, 
	"REV_RATE" NUMBER DEFAULT NULL, 
	"REV_COMMENT" VARCHAR2(200) DEFAULT NULL, 
	"REV_DATE" DATE, 
	"USERID" NUMBER, 
	"MOVIEID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table SERIES
--------------------------------------------------------

  CREATE TABLE "SERIES" 
   (	"S_ID" NUMBER, 
	"S_NAME" VARCHAR2(20), 
	"S_DESC" VARCHAR2(200), 
	"S_RATE" NUMBER, 
	"S_LANG" VARCHAR2(20), 
	"S_TYPE" VARCHAR2(20)
   ) ;
--------------------------------------------------------
--  DDL for Table SERIES_ACTED_BY
--------------------------------------------------------

  CREATE TABLE "SERIES_ACTED_BY" 
   (	"ACTORID" NUMBER, 
	"SERIESID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table SERIES_GENRE
--------------------------------------------------------

  CREATE TABLE "SERIES_GENRE" 
   (	"GEN_ID" NUMBER, 
	"GEN_NAME" VARCHAR2(20), 
	"SERIESID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table SUBSCRIBTION
--------------------------------------------------------

  CREATE TABLE "SUBSCRIBTION" 
   (	"SUB_TYPE" NUMBER, 
	"START_DATE" DATE, 
	"USERID" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table S_USER
--------------------------------------------------------

  CREATE TABLE "S_USER" 
   (	"USER_ID" NUMBER, 
	"USERNAME" VARCHAR2(20), 
	"PASSWORD" VARCHAR2(200), 
	"U_FNAME" VARCHAR2(20), 
	"U_LNAME" VARCHAR2(20), 
	"U_BDATE" DATE, 
	"U_GENDER" VARCHAR2(20), 
	"EMAIL" VARCHAR2(200), 
	"CREDIT_CARD" NUMBER DEFAULT null
   ) ;
--------------------------------------------------------
--  DDL for Table WATCHES_EPISODE
--------------------------------------------------------

  CREATE TABLE "WATCHES_EPISODE" 
   (	"USERID" NUMBER, 
	"EPISODEID" NUMBER, 
	"WATCH_TIME" NUMBER DEFAULT 0
   ) ;
--------------------------------------------------------
--  DDL for Table WATCHES_MOVIE
--------------------------------------------------------

  CREATE TABLE "WATCHES_MOVIE" 
   (	"USERID" NUMBER, 
	"MOVIEID" NUMBER, 
	"WATCH_TIME" NUMBER DEFAULT 0
   ) ;

---------------------------------------------------
--   DATA FOR TABLE ACTOR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ACTOR
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (4,'C','A',to_timestamp('13-NOV-19 12.32.07.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'Male');
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (5,'S','J',to_timestamp('13-FEB-19 12.32.07.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'Female');
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (7,'t','t',to_timestamp('12-APR-20 07.17.34.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Female');
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (2,'co','co',to_timestamp('15-JAN-20 09.26.41.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Male');
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (3,'ged','coc',to_timestamp('31-AUG-19 09.26.41.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Male');
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (6,'s','s',to_timestamp('12-APR-20 04.57.20.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'Male');
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (8,'h','e',to_timestamp('13-APR-20 11.13.13.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Female');
Insert into ACTOR (A_ID,A_FNAME,A_LNAME,A_BDATE,A_GENDER) values (9,'v','v',to_timestamp('06-NOV-19 11.13.13.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Female');

---------------------------------------------------
--   END DATA FOR TABLE ACTOR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ADDS_EPISODE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ADDS_EPISODE

---------------------------------------------------
--   END DATA FOR TABLE ADDS_EPISODE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ADDS_MOVIE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ADDS_MOVIE

---------------------------------------------------
--   END DATA FOR TABLE ADDS_MOVIE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EPISODE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EPISODE
Insert into EPISODE (EP_ID,EP_NUMBER,EP_SEASON,EP_LEN,EP_DATE,SERIESID,EP_IMG,EP_VID) values (15,1,1,34,to_timestamp('14-APR-20 02.54.04.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),23,'(BLOB)','(BLOB)');

---------------------------------------------------
--   END DATA FOR TABLE EPISODE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE MOVIE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into MOVIE
Insert into MOVIE (MOV_ID,MOV_NAME,MOV_DESC,MOV_RATE,MOV_LEN,MOV_LANG,MOV_DATE,MOV_IMG,MOV_TYPE,MOV_VID) values (72,'jj','et3amlooo edit taltttttttttt',1,9,'Arabic',to_timestamp('13-APR-20 11.30.11.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'(BLOB)','free','(BLOB)');
Insert into MOVIE (MOV_ID,MOV_NAME,MOV_DESC,MOV_RATE,MOV_LEN,MOV_LANG,MOV_DATE,MOV_IMG,MOV_TYPE,MOV_VID) values (73,'fhjk','vgbhjnmk',88,787,'English',to_timestamp('15-APR-20 01.18.14.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),'(BLOB)','premium','(BLOB)');

---------------------------------------------------
--   END DATA FOR TABLE MOVIE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE MOVIE_ACTED_BY
--   FILTER = none used
---------------------------------------------------
REM INSERTING into MOVIE_ACTED_BY
Insert into MOVIE_ACTED_BY (ACTORID,MOVIEID) values (2,72);
Insert into MOVIE_ACTED_BY (ACTORID,MOVIEID) values (4,73);

---------------------------------------------------
--   END DATA FOR TABLE MOVIE_ACTED_BY
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE MOVIE_GENRE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into MOVIE_GENRE
Insert into MOVIE_GENRE (GEN_ID,GEN_NAME,MOVIEID) values (36,'Westerns',72);
Insert into MOVIE_GENRE (GEN_ID,GEN_NAME,MOVIEID) values (37,'Historical',73);
Insert into MOVIE_GENRE (GEN_ID,GEN_NAME,MOVIEID) values (38,'Comedy',73);

---------------------------------------------------
--   END DATA FOR TABLE MOVIE_GENRE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE REV_EPISODE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into REV_EPISODE
Insert into REV_EPISODE (REV_ID,REV_RATE,REV_COMMENT,REV_DATE,USERID,EPISODEID) values (1,8,'edittttttt',to_timestamp('14-APR-20 08.20.56.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),4,15);

---------------------------------------------------
--   END DATA FOR TABLE REV_EPISODE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE REV_MOVIE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into REV_MOVIE
Insert into REV_MOVIE (REV_ID,REV_RATE,REV_COMMENT,REV_DATE,USERID,MOVIEID) values (22,6,'tttttttttttttttt',to_timestamp('14-APR-20 06.51.52.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),5,72);
Insert into REV_MOVIE (REV_ID,REV_RATE,REV_COMMENT,REV_DATE,USERID,MOVIEID) values (19,9,'edittttt',to_timestamp('14-APR-20 08.21.37.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),4,72);
Insert into REV_MOVIE (REV_ID,REV_RATE,REV_COMMENT,REV_DATE,USERID,MOVIEID) values (21,null,'rdftvgbhjn',to_timestamp('14-APR-20 06.48.48.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),7,72);

---------------------------------------------------
--   END DATA FOR TABLE REV_MOVIE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE SERIES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into SERIES
Insert into SERIES (S_ID,S_NAME,S_DESC,S_RATE,S_LANG,S_TYPE) values (23,'asd','ftvbghnj',1,'Arabic','free');

---------------------------------------------------
--   END DATA FOR TABLE SERIES
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE SERIES_ACTED_BY
--   FILTER = none used
---------------------------------------------------
REM INSERTING into SERIES_ACTED_BY
Insert into SERIES_ACTED_BY (ACTORID,SERIESID) values (2,23);
Insert into SERIES_ACTED_BY (ACTORID,SERIESID) values (6,23);

---------------------------------------------------
--   END DATA FOR TABLE SERIES_ACTED_BY
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE SERIES_GENRE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into SERIES_GENRE
Insert into SERIES_GENRE (GEN_ID,GEN_NAME,SERIESID) values (30,'Philosophical',23);

---------------------------------------------------
--   END DATA FOR TABLE SERIES_GENRE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE SUBSCRIBTION
--   FILTER = none used
---------------------------------------------------
REM INSERTING into SUBSCRIBTION
Insert into SUBSCRIBTION (SUB_TYPE,START_DATE,USERID) values (2,to_timestamp('14-APR-20 12.40.20.000000000 AM','DD-MON-RR HH.MI.SS.FF AM'),4);
Insert into SUBSCRIBTION (SUB_TYPE,START_DATE,USERID) values (1,to_timestamp('11-APR-20 07.36.18.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),5);

---------------------------------------------------
--   END DATA FOR TABLE SUBSCRIBTION
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE S_USER
--   FILTER = none used
---------------------------------------------------
REM INSERTING into S_USER
Insert into S_USER (USER_ID,USERNAME,PASSWORD,U_FNAME,U_LNAME,U_BDATE,U_GENDER,EMAIL,CREDIT_CARD) values (8,'ss','ss','s','s',to_timestamp('07-APR-20 02.11.56.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Male','ss',123);
Insert into S_USER (USER_ID,USERNAME,PASSWORD,U_FNAME,U_LNAME,U_BDATE,U_GENDER,EMAIL,CREDIT_CARD) values (4,'cd','cd','c','d',to_timestamp('01-APR-20 11.58.49.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Male','cd@gmailcom',345786);
Insert into S_USER (USER_ID,USERNAME,PASSWORD,U_FNAME,U_LNAME,U_BDATE,U_GENDER,EMAIL,CREDIT_CARD) values (5,'qw','qw','q','w',to_timestamp('07-APR-20 02.08.10.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Male','qw2as',5678);
Insert into S_USER (USER_ID,USERNAME,PASSWORD,U_FNAME,U_LNAME,U_BDATE,U_GENDER,EMAIL,CREDIT_CARD) values (7,'qq','qq','q','q',to_timestamp('07-APR-20 02.09.08.000000000 PM','DD-MON-RR HH.MI.SS.FF AM'),'Male','qq',5678);

---------------------------------------------------
--   END DATA FOR TABLE S_USER
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE WATCHES_EPISODE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into WATCHES_EPISODE
Insert into WATCHES_EPISODE (USERID,EPISODEID,WATCH_TIME) values (4,15,2);

---------------------------------------------------
--   END DATA FOR TABLE WATCHES_EPISODE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE WATCHES_MOVIE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into WATCHES_MOVIE
Insert into WATCHES_MOVIE (USERID,MOVIEID,WATCH_TIME) values (4,72,1);

---------------------------------------------------
--   END DATA FOR TABLE WATCHES_MOVIE
---------------------------------------------------

--------------------------------------------------------
--  Constraints for Table SERIES_GENRE
--------------------------------------------------------

  ALTER TABLE "SERIES_GENRE" ADD CONSTRAINT "SERIES_GENRE_PK" PRIMARY KEY ("GEN_ID", "SERIESID") ENABLE;
 
  ALTER TABLE "SERIES_GENRE" MODIFY ("GEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "SERIES_GENRE" MODIFY ("GEN_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "SERIES_GENRE" MODIFY ("SERIESID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ACTOR
--------------------------------------------------------

  ALTER TABLE "ACTOR" ADD CONSTRAINT "ACTOR_PK" PRIMARY KEY ("A_ID") ENABLE;
 
  ALTER TABLE "ACTOR" MODIFY ("A_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ACTOR" MODIFY ("A_FNAME" NOT NULL ENABLE);
 
  ALTER TABLE "ACTOR" MODIFY ("A_LNAME" NOT NULL ENABLE);
 
  ALTER TABLE "ACTOR" MODIFY ("A_BDATE" NOT NULL ENABLE);
 
  ALTER TABLE "ACTOR" MODIFY ("A_GENDER" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table MOVIE
--------------------------------------------------------

  ALTER TABLE "MOVIE" ADD CONSTRAINT "MOVIE_PK" PRIMARY KEY ("MOV_ID") ENABLE;
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_DESC" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_RATE" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_LEN" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_LANG" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE" MODIFY ("MOV_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SUBSCRIBTION
--------------------------------------------------------

  ALTER TABLE "SUBSCRIBTION" ADD CONSTRAINT "SUBSCRIBTION_PK" PRIMARY KEY ("SUB_TYPE", "USERID") ENABLE;
 
  ALTER TABLE "SUBSCRIBTION" MODIFY ("SUB_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "SUBSCRIBTION" MODIFY ("START_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "SUBSCRIBTION" MODIFY ("USERID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SERIES
--------------------------------------------------------

  ALTER TABLE "SERIES" ADD CONSTRAINT "SERIES_PK" PRIMARY KEY ("S_ID") ENABLE;
 
  ALTER TABLE "SERIES" MODIFY ("S_ID" NOT NULL ENABLE);
 
  ALTER TABLE "SERIES" MODIFY ("S_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "SERIES" MODIFY ("S_DESC" NOT NULL ENABLE);
 
  ALTER TABLE "SERIES" MODIFY ("S_RATE" NOT NULL ENABLE);
 
  ALTER TABLE "SERIES" MODIFY ("S_LANG" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table S_USER
--------------------------------------------------------

  ALTER TABLE "S_USER" MODIFY ("USER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" MODIFY ("USERNAME" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" MODIFY ("PASSWORD" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" MODIFY ("U_FNAME" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" MODIFY ("U_LNAME" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" MODIFY ("U_BDATE" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" MODIFY ("U_GENDER" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" MODIFY ("EMAIL" NOT NULL ENABLE);
 
  ALTER TABLE "S_USER" ADD CONSTRAINT "S_USER_PK" PRIMARY KEY ("USER_ID") ENABLE;
 
  ALTER TABLE "S_USER" ADD CONSTRAINT "S_USER_UNIQUE" UNIQUE ("USERNAME", "EMAIL", "CREDIT_CARD") ENABLE;
--------------------------------------------------------
--  Constraints for Table WATCHES_MOVIE
--------------------------------------------------------

  ALTER TABLE "WATCHES_MOVIE" MODIFY ("USERID" NOT NULL ENABLE);
 
  ALTER TABLE "WATCHES_MOVIE" MODIFY ("MOVIEID" NOT NULL ENABLE);
 
  ALTER TABLE "WATCHES_MOVIE" ADD CONSTRAINT "WATCHES_MOVIE_PK" PRIMARY KEY ("USERID", "MOVIEID") ENABLE;
--------------------------------------------------------
--  Constraints for Table REV_MOVIE
--------------------------------------------------------

  ALTER TABLE "REV_MOVIE" ADD CONSTRAINT "REVIEW_PK" PRIMARY KEY ("REV_ID") ENABLE;
 
  ALTER TABLE "REV_MOVIE" MODIFY ("REV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "REV_MOVIE" MODIFY ("REV_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "REV_MOVIE" MODIFY ("USERID" NOT NULL ENABLE);
 
  ALTER TABLE "REV_MOVIE" MODIFY ("MOVIEID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EPISODE
--------------------------------------------------------

  ALTER TABLE "EPISODE" ADD CONSTRAINT "EPISODE_PK" PRIMARY KEY ("EP_ID") ENABLE;
 
  ALTER TABLE "EPISODE" MODIFY ("EP_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EPISODE" MODIFY ("EP_NUMBER" NOT NULL ENABLE);
 
  ALTER TABLE "EPISODE" MODIFY ("EP_SEASON" NOT NULL ENABLE);
 
  ALTER TABLE "EPISODE" MODIFY ("EP_LEN" NOT NULL ENABLE);
 
  ALTER TABLE "EPISODE" MODIFY ("EP_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "EPISODE" MODIFY ("SERIESID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ADDS_MOVIE
--------------------------------------------------------

  ALTER TABLE "ADDS_MOVIE" ADD CONSTRAINT "ADDS_MOVIE_PK" PRIMARY KEY ("USERID", "MOVIEID") ENABLE;
 
  ALTER TABLE "ADDS_MOVIE" MODIFY ("USERID" NOT NULL ENABLE);
 
  ALTER TABLE "ADDS_MOVIE" MODIFY ("MOVIEID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table REV_EPISODE
--------------------------------------------------------

  ALTER TABLE "REV_EPISODE" ADD CONSTRAINT "REV_EPISODE_PK" PRIMARY KEY ("REV_ID") ENABLE;
 
  ALTER TABLE "REV_EPISODE" MODIFY ("REV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "REV_EPISODE" MODIFY ("REV_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table MOVIE_ACTED_BY
--------------------------------------------------------

  ALTER TABLE "MOVIE_ACTED_BY" ADD CONSTRAINT "MOVIE_ACTED_BY_PK" PRIMARY KEY ("ACTORID", "MOVIEID") ENABLE;
 
  ALTER TABLE "MOVIE_ACTED_BY" MODIFY ("ACTORID" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE_ACTED_BY" MODIFY ("MOVIEID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table MOVIE_GENRE
--------------------------------------------------------

  ALTER TABLE "MOVIE_GENRE" ADD CONSTRAINT "MOVIE_GENRE_PK" PRIMARY KEY ("GEN_ID", "MOVIEID") ENABLE;
 
  ALTER TABLE "MOVIE_GENRE" MODIFY ("GEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "MOVIE_GENRE" MODIFY ("MOVIEID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ADDS_EPISODE
--------------------------------------------------------

  ALTER TABLE "ADDS_EPISODE" ADD CONSTRAINT "ADDS_SERIES_PK" PRIMARY KEY ("USERID", "EPISODEID") ENABLE;
 
  ALTER TABLE "ADDS_EPISODE" MODIFY ("USERID" NOT NULL ENABLE);
 
  ALTER TABLE "ADDS_EPISODE" MODIFY ("EPISODEID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table WATCHES_EPISODE
--------------------------------------------------------

  ALTER TABLE "WATCHES_EPISODE" MODIFY ("USERID" NOT NULL ENABLE);
 
  ALTER TABLE "WATCHES_EPISODE" MODIFY ("EPISODEID" NOT NULL ENABLE);
 
  ALTER TABLE "WATCHES_EPISODE" ADD CONSTRAINT "WATCHES_EPISODE_PK" PRIMARY KEY ("USERID", "EPISODEID") ENABLE;
--------------------------------------------------------
--  Constraints for Table SERIES_ACTED_BY
--------------------------------------------------------

  ALTER TABLE "SERIES_ACTED_BY" ADD CONSTRAINT "SERIES_ACTED_BY_PK" PRIMARY KEY ("ACTORID", "SERIESID") ENABLE;
 
  ALTER TABLE "SERIES_ACTED_BY" MODIFY ("ACTORID" NOT NULL ENABLE);
 
  ALTER TABLE "SERIES_ACTED_BY" MODIFY ("SERIESID" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index MOVIE_GENRE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "MOVIE_GENRE_PK" ON "MOVIE_GENRE" ("GEN_ID", "MOVIEID") 
  ;
--------------------------------------------------------
--  DDL for Index SERIES_GENRE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SERIES_GENRE_PK" ON "SERIES_GENRE" ("GEN_ID", "SERIESID") 
  ;
--------------------------------------------------------
--  DDL for Index EPISODE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "EPISODE_PK" ON "EPISODE" ("EP_ID") 
  ;
--------------------------------------------------------
--  DDL for Index ACTOR_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ACTOR_PK" ON "ACTOR" ("A_ID") 
  ;
--------------------------------------------------------
--  DDL for Index SERIES_ACTED_BY_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SERIES_ACTED_BY_PK" ON "SERIES_ACTED_BY" ("ACTORID", "SERIESID") 
  ;
--------------------------------------------------------
--  DDL for Index MOVIE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "MOVIE_PK" ON "MOVIE" ("MOV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index WATCHES_MOVIE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "WATCHES_MOVIE_PK" ON "WATCHES_MOVIE" ("USERID", "MOVIEID") 
  ;
--------------------------------------------------------
--  DDL for Index ADDS_MOVIE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ADDS_MOVIE_PK" ON "ADDS_MOVIE" ("USERID", "MOVIEID") 
  ;
--------------------------------------------------------
--  DDL for Index WATCHES_EPISODE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "WATCHES_EPISODE_PK" ON "WATCHES_EPISODE" ("USERID", "EPISODEID") 
  ;
--------------------------------------------------------
--  DDL for Index MOVIE_ACTED_BY_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "MOVIE_ACTED_BY_PK" ON "MOVIE_ACTED_BY" ("ACTORID", "MOVIEID") 
  ;
--------------------------------------------------------
--  DDL for Index ADDS_SERIES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ADDS_SERIES_PK" ON "ADDS_EPISODE" ("USERID", "EPISODEID") 
  ;
--------------------------------------------------------
--  DDL for Index SUBSCRIBTION_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SUBSCRIBTION_PK" ON "SUBSCRIBTION" ("SUB_TYPE", "USERID") 
  ;
--------------------------------------------------------
--  DDL for Index REVIEW_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "REVIEW_PK" ON "REV_MOVIE" ("REV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index S_USER_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "S_USER_PK" ON "S_USER" ("USER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index REV_EPISODE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "REV_EPISODE_PK" ON "REV_EPISODE" ("REV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index SERIES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SERIES_PK" ON "SERIES" ("S_ID") 
  ;
--------------------------------------------------------
--  DDL for Index S_USER_UNIQUE
--------------------------------------------------------

  CREATE UNIQUE INDEX "S_USER_UNIQUE" ON "S_USER" ("USERNAME", "EMAIL", "CREDIT_CARD") 
  ;

--------------------------------------------------------
--  Ref Constraints for Table ADDS_EPISODE
--------------------------------------------------------

  ALTER TABLE "ADDS_EPISODE" ADD CONSTRAINT "ADDS_SERIES_EPISODE" FOREIGN KEY ("EPISODEID")
	  REFERENCES "EPISODE" ("EP_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "ADDS_EPISODE" ADD CONSTRAINT "ADDS_SERIES_USER" FOREIGN KEY ("USERID")
	  REFERENCES "S_USER" ("USER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ADDS_MOVIE
--------------------------------------------------------

  ALTER TABLE "ADDS_MOVIE" ADD CONSTRAINT "ADDS_MOVIE_MOVIE" FOREIGN KEY ("MOVIEID")
	  REFERENCES "MOVIE" ("MOV_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "ADDS_MOVIE" ADD CONSTRAINT "ADDS_MOVIE_USER" FOREIGN KEY ("USERID")
	  REFERENCES "S_USER" ("USER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EPISODE
--------------------------------------------------------

  ALTER TABLE "EPISODE" ADD CONSTRAINT "EPISODE_SERIES_FK" FOREIGN KEY ("SERIESID")
	  REFERENCES "SERIES" ("S_ID") ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table MOVIE_ACTED_BY
--------------------------------------------------------

  ALTER TABLE "MOVIE_ACTED_BY" ADD CONSTRAINT "MOVIE_ACTED_BY_ACTOR" FOREIGN KEY ("ACTORID")
	  REFERENCES "ACTOR" ("A_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "MOVIE_ACTED_BY" ADD CONSTRAINT "MOVIE_ACTED_BY_MOVIE" FOREIGN KEY ("MOVIEID")
	  REFERENCES "MOVIE" ("MOV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table MOVIE_GENRE
--------------------------------------------------------

  ALTER TABLE "MOVIE_GENRE" ADD CONSTRAINT "MOVIE_GENRE_MOVIE" FOREIGN KEY ("MOVIEID")
	  REFERENCES "MOVIE" ("MOV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table REV_EPISODE
--------------------------------------------------------

  ALTER TABLE "REV_EPISODE" ADD CONSTRAINT "REV_EPISODE_EPISODE" FOREIGN KEY ("EPISODEID")
	  REFERENCES "EPISODE" ("EP_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "REV_EPISODE" ADD CONSTRAINT "REV_EPISODE_USER" FOREIGN KEY ("USERID")
	  REFERENCES "S_USER" ("USER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table REV_MOVIE
--------------------------------------------------------

  ALTER TABLE "REV_MOVIE" ADD CONSTRAINT "REVIEW_MOVIE" FOREIGN KEY ("MOVIEID")
	  REFERENCES "MOVIE" ("MOV_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "REV_MOVIE" ADD CONSTRAINT "REVIEW_S_USER" FOREIGN KEY ("USERID")
	  REFERENCES "S_USER" ("USER_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table SERIES_ACTED_BY
--------------------------------------------------------

  ALTER TABLE "SERIES_ACTED_BY" ADD CONSTRAINT "SERIES_ACTED_BY_ACTOR" FOREIGN KEY ("ACTORID")
	  REFERENCES "ACTOR" ("A_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "SERIES_ACTED_BY" ADD CONSTRAINT "SERIES_ACTED_BY_SERIES" FOREIGN KEY ("SERIESID")
	  REFERENCES "SERIES" ("S_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table SERIES_GENRE
--------------------------------------------------------

  ALTER TABLE "SERIES_GENRE" ADD CONSTRAINT "SERIES_GENRE_SERIES" FOREIGN KEY ("SERIESID")
	  REFERENCES "SERIES" ("S_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table SUBSCRIBTION
--------------------------------------------------------

  ALTER TABLE "SUBSCRIBTION" ADD CONSTRAINT "SUBSCRIBTION_USER" FOREIGN KEY ("USERID")
	  REFERENCES "S_USER" ("USER_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table WATCHES_EPISODE
--------------------------------------------------------

  ALTER TABLE "WATCHES_EPISODE" ADD CONSTRAINT "WATCHES_EPISODE_EPISODE" FOREIGN KEY ("EPISODEID")
	  REFERENCES "EPISODE" ("EP_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "WATCHES_EPISODE" ADD CONSTRAINT "WATCHES_EPISODE_USER" FOREIGN KEY ("USERID")
	  REFERENCES "S_USER" ("USER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table WATCHES_MOVIE
--------------------------------------------------------

  ALTER TABLE "WATCHES_MOVIE" ADD CONSTRAINT "WATCHES_MOVIE_MOVIE" FOREIGN KEY ("MOVIEID")
	  REFERENCES "MOVIE" ("MOV_ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "WATCHES_MOVIE" ADD CONSTRAINT "WATCHES_MOVIE_USER" FOREIGN KEY ("USERID")
	  REFERENCES "S_USER" ("USER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  DDL for Trigger ACTOR_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ACTOR_BI" 
BEFORE INSERT ON actor
FOR EACH ROW
BEGIN
  SELECT actor_id_seq.nextval
  INTO :new.a_id
  FROM dual;
END;
/
ALTER TRIGGER "ACTOR_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger EPISODE_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "EPISODE_BI" 
BEFORE INSERT ON episode
FOR EACH ROW
BEGIN
  SELECT episode_id_seq.nextval
  INTO :new.ep_id
  FROM dual;
END;
/
ALTER TRIGGER "EPISODE_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger GEN_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "GEN_BI" 
BEFORE INSERT ON series_genre
FOR EACH ROW
BEGIN
  SELECT s_gen_id_seq.nextval
  INTO :new.gen_id
  FROM dual;
END;
/
ALTER TRIGGER "GEN_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger MOVIE_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "MOVIE_BI" 
BEFORE INSERT ON movie
FOR EACH ROW
BEGIN
  SELECT movie_id_seq.nextval
  INTO :new.mov_id
  FROM dual;
END;
/
ALTER TRIGGER "MOVIE_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger M_GEN_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "M_GEN_BI" 
BEFORE INSERT ON movie_genre
FOR EACH ROW
BEGIN
  SELECT m_gen_id_seq.nextval
  INTO :new.gen_id
  FROM dual;
END;
/
ALTER TRIGGER "M_GEN_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger REV_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "REV_BI" 
BEFORE INSERT ON REV_MOVIE
FOR EACH ROW
BEGIN
  SELECT rev_id_seq.nextval
  INTO :new.rev_id
  FROM dual;
END;
/
ALTER TRIGGER "REV_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger REV_EP_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "REV_EP_BI" 
BEFORE INSERT ON REV_episode
FOR EACH ROW
BEGIN
  SELECT rev_id_ep_seq.nextval
  INTO :new.rev_id
  FROM dual;
END;
/
ALTER TRIGGER "REV_EP_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger SERIES_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "SERIES_BI" 
BEFORE INSERT ON series
FOR EACH ROW
BEGIN
  SELECT series_id_seq.nextval
  INTO :new.s_id
  FROM dual;
END;
/
ALTER TRIGGER "SERIES_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger S_GEN_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "S_GEN_BI" 
BEFORE INSERT ON series_genre
FOR EACH ROW
BEGIN
  SELECT s_gen_id_seq.nextval
  INTO :new.gen_id
  FROM dual;
END;

/
ALTER TRIGGER "S_GEN_BI" ENABLE;
--------------------------------------------------------
--  DDL for Trigger USER_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "USER_BI" 
BEFORE INSERT ON s_user
FOR EACH ROW
BEGIN
  SELECT user_id_seq.nextval
  INTO :new.user_id
  FROM dual;
END;

/
ALTER TRIGGER "USER_BI" ENABLE;
--------------------------------------------------------
--  DDL for Procedure DELETE_EPISODE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "DELETE_EPISODE" (ep_num in INTEGER, ep_season in INTEGER, s_id in INTEGER)
as
begin

delete from episode where ep_number = ep_num and ep_season = ep_season and seriesid = s_id;

end;

/

--------------------------------------------------------
--  DDL for Procedure DELETE_MOVIE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "DELETE_MOVIE" (m_id in INTEGER)
as
begin

delete from movie where mov_id = m_id;

end;

/

--------------------------------------------------------
--  DDL for Procedure DELETE_SERIES
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "DELETE_SERIES" (e_num in INTEGER, e_season in integer ,se_id in INTEGER)
as
begin
delete from episode where ep_number = e_num and ep_season = e_season and seriesid = se_id;
delete from series where s_id = se_id;
end;

/

--------------------------------------------------------
--  DDL for Procedure END_SUBSCRIBTION
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "END_SUBSCRIBTION" (user_id in INTEGER, end_date out date)
is
s_start date;
s_type INTEGER := 0;
begin
select start_date into s_start from subscribtion where userid = user_id;
select sub_type into s_type from subscribtion where userid = user_id;

if s_type = 1 then
  end_date := s_start + 7;
elsif s_type = 2 then
  end_date := s_start + 30;
else
  end_date := s_start + 365;
  
end if;
end;

/

--------------------------------------------------------
--  DDL for Procedure GETEPISODEREV
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GETEPISODEREV" 
(e_id in INTEGER, all_rev out sys_refcursor)
as

begin

open all_rev for

select s.username, r.rev_rate, r.rev_comment, r.rev_date from rev_episode r, s_user s where r.episodeid = e_id and r.userid = s.user_id order by r.rev_date;
end;

/

--------------------------------------------------------
--  DDL for Procedure GETMOVIEREV
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GETMOVIEREV" 
(m_id in INTEGER, all_rev out sys_refcursor)
as

begin

open all_rev for

select s.username, r.rev_rate, r.rev_comment, r.rev_date from rev_movie r, s_user s where r.movieid = m_id and r.userid = s.user_id order by r.rev_date;
end;

/

--------------------------------------------------------
--  DDL for Procedure GET_ACTORS
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GET_ACTORS" (all_actors out sys_refcursor)
as
begin

open all_actors for

select a_fname, a_lname from actor;

end;

/

--------------------------------------------------------
--  DDL for Procedure GET_ACTOR_ID
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GET_ACTOR_ID" 
(fname in actor.a_fname%type,
sname in actor.a_lname%type,
actor_id out INTEGER)
as
begin

select a_id into actor_id from actor where a_fname = fname and a_lname = sname;
end;

/

--------------------------------------------------------
--  DDL for Procedure GET_MOVIE_ID
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GET_MOVIE_ID" 
(m_name in movie.mov_name%type,
m_id out INTEGER)
as
begin

select mov_id into m_id from movie where mov_name = m_name;
end;

/

--------------------------------------------------------
--  DDL for Procedure GET_SERIES_ID
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GET_SERIES_ID" 
(series_name in series.s_name%type,
series_id out INTEGER)
as
begin

select s_id into series_id from series where s_name = series_name;
end;

/

--------------------------------------------------------
--  DDL for Procedure GET_SERIES_NAMES
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "GET_SERIES_NAMES" (all_series out sys_refcursor)
as
begin

open all_series for

select s_name from series;

end;

/

--------------------------------------------------------
--  DDL for Procedure INSERT_ACTOR
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "INSERT_ACTOR" 
(fname in VARCHAR2, lname in VARCHAR2, gender in VARCHAR2, bdate in date)
as
begin

insert into actor (a_fname, a_lname, a_gender, a_bdate) values
(fname, lname, gender, bdate);

end;

/

--------------------------------------------------------
--  DDL for Procedure INSERT_MOVIE_ACTED_BY
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "INSERT_MOVIE_ACTED_BY" (a_id in INTEGER, m_id in INTEGER)
as
begin

insert into movie_acted_by (actorid, movieid) values (a_id, m_id);

end;

/

--------------------------------------------------------
--  DDL for Procedure INSERT_MOVIE_GENRE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "INSERT_MOVIE_GENRE" 
(m_id in INTEGER, g_name in movie_genre.gen_name%type)
as
begin

insert into movie_genre (movieid, gen_name) values
(m_id, g_name);

end;

/

--------------------------------------------------------
--  DDL for Procedure INSERT_SERIES_ACTED_BY
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "INSERT_SERIES_ACTED_BY" (a_id in INTEGER, m_id in INTEGER)
as
begin

insert into series_acted_by (actorid, seriesid) values (a_id, m_id);

end;

/

--------------------------------------------------------
--  DDL for Procedure INSERT_SERIES_GENRE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "INSERT_SERIES_GENRE" 
(series_id in INTEGER, g_name in series_genre.gen_name%type)
as
begin

insert into series_genre (seriesid, gen_name) values
(series_id, g_name);

end;

/

--------------------------------------------------------
--  DDL for Procedure REMOVE_FAV_EPISODE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "REMOVE_FAV_EPISODE" 
(user_id in INTEGER, e_id in INTEGER)
as
begin
delete from adds_episode where userid = user_id and episodeid = e_id;
end;

/

--------------------------------------------------------
--  DDL for Procedure REMOVE_FAV_MOVIE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "REMOVE_FAV_MOVIE" 
(user_id in INTEGER, mov_id in INTEGER)
as
begin
delete from adds_movie where userid = user_id and movieid = mov_id;
end;

/

--------------------------------------------------------
--  DDL for Procedure SEARCH_MOVIES
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "SEARCH_MOVIES" (search in movie.mov_name%type ,all_movies out sys_refcursor)
as
begin
open all_movies for
SELECT mov_id, mov_name, mov_rate, mov_len, mov_img, mov_type from movie  where mov_name like '%' || search ||'%';
end;

/

--------------------------------------------------------
--  DDL for Procedure SEARCH_SERIES
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "SEARCH_SERIES" (search in series.s_name%type ,all_movies out sys_refcursor)
as
begin
open all_movies for

SELECT s.s_name, s.s_rate, s.s_type, e.ep_id,e.ep_number, e.ep_season, e.ep_len, e.ep_img  from series s , episode e where s.s_name  like '%' || search ||'%' and s.s_id = e.seriesid;


end;

/

--------------------------------------------------------
--  DDL for Procedure UPDATE_CCN
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "UPDATE_CCN" 
(ccn in INTEGER, userid in INTEGER)
as
begin
update s_user set credit_card = ccn where user_id = userid;
end;

/

--------------------------------------------------------
--  DDL for Procedure UPDATE_EP_REV
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "UPDATE_EP_REV" 
(e_id in INTEGER, u_id in INTEGER, r_rate in INTEGER, r_comment in rev_episode.rev_comment%type)
as
begin

UPDATE rev_episode set rev_rate = r_rate , rev_comment = r_comment, rev_date = sysdate where episodeid = e_id and userid = u_id;

end;

/

--------------------------------------------------------
--  DDL for Procedure UPDATE_MOV_REV
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "UPDATE_MOV_REV" 
(m_id in INTEGER, u_id in INTEGER, r_rate in INTEGER, r_comment in rev_movie.rev_comment%type)
as
begin

UPDATE rev_movie set rev_rate = r_rate , rev_comment = r_comment, rev_date = sysdate where movieid = m_id and userid = u_id;

end;

/

