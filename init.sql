CREATE TABLE public.users (
	userid serial NOT NULL,
	firstname varchar(50) NOT NULL,
	lastname varchar(50) NOT NULL,
	username varchar(50) NOT NULL,
	"Password" varchar(50) NOT NULL,
	CONSTRAINT users_pk PRIMARY KEY (userid)
);

INSERT INTO public.users
(userid, firstname, lastname, username, "Password")
VALUES(nextval('users_userid_seq'::regclass), 'juan', 'pimentel', 'juanpimentel', '1234');

CREATE OR REPLACE FUNCTION public.fn_users_get_by_user_and_password(
   username varchar(50),
   password varchar(50)
)
RETURNS TABLE(userId int, firstname varchar(50), lastname varchar(50), username varchar(50), password varchar(50))
LANGUAGE sql AS
$function$
    SELECT userId, firstname, lastname, username, NULL as Password
    FROM users
    WHERE userName = username and password = password;
$function$;