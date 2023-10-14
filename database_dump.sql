--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: ammunition; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ammunition (
    ammunition_id integer NOT NULL,
    type character varying(50) NOT NULL,
    name character varying(255) NOT NULL,
    price numeric(10,2) NOT NULL,
    size character varying(20) NOT NULL,
    users_gender character varying(10) NOT NULL,
    user_id integer
);


ALTER TABLE public.ammunition OWNER TO postgres;

--
-- Name: ammunition_ammunition_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ammunition_ammunition_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ammunition_ammunition_id_seq OWNER TO postgres;

--
-- Name: ammunition_ammunition_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ammunition_ammunition_id_seq OWNED BY public.ammunition.ammunition_id;


--
-- Name: inventory_ammunition; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.inventory_ammunition (
    inventory_ammunition_id integer NOT NULL,
    ammunition_id integer,
    general_ammunition integer NOT NULL,
    storage_ammunition integer NOT NULL
);


ALTER TABLE public.inventory_ammunition OWNER TO postgres;

--
-- Name: inventory_ammunition_inventory_ammunition_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.inventory_ammunition_inventory_ammunition_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.inventory_ammunition_inventory_ammunition_id_seq OWNER TO postgres;

--
-- Name: inventory_ammunition_inventory_ammunition_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.inventory_ammunition_inventory_ammunition_id_seq OWNED BY public.inventory_ammunition.inventory_ammunition_id;


--
-- Name: inventory_weapon; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.inventory_weapon (
    inventory_weapon_id integer NOT NULL,
    weapon_id integer,
    general_quantity integer NOT NULL,
    storage_quantity integer NOT NULL
);


ALTER TABLE public.inventory_weapon OWNER TO postgres;

--
-- Name: inventory_weapon_inventory_weapon_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.inventory_weapon_inventory_weapon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.inventory_weapon_inventory_weapon_id_seq OWNER TO postgres;

--
-- Name: inventory_weapon_inventory_weapon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.inventory_weapon_inventory_weapon_id_seq OWNED BY public.inventory_weapon.inventory_weapon_id;


--
-- Name: requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.requests (
    request_id integer NOT NULL,
    senter_soldier integer,
    receiver_admin integer,
    weapon_id integer,
    ammunition_id integer,
    quantity_requested integer NOT NULL,
    message text,
    request_status character varying(20) NOT NULL
);


ALTER TABLE public.requests OWNER TO postgres;

--
-- Name: requests_request_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.requests_request_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.requests_request_id_seq OWNER TO postgres;

--
-- Name: requests_request_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.requests_request_id_seq OWNED BY public.requests.request_id;


--
-- Name: routes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.routes (
    route_id integer NOT NULL,
    volunteer_id integer,
    weapon_id integer,
    ammunition_id integer,
    starting_point character varying(255) NOT NULL,
    destination_point character varying(255) NOT NULL,
    quantity_delivered integer NOT NULL,
    delivery_date date NOT NULL
);


ALTER TABLE public.routes OWNER TO postgres;

--
-- Name: routes_route_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.routes_route_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.routes_route_id_seq OWNER TO postgres;

--
-- Name: routes_route_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.routes_route_id_seq OWNED BY public.routes.route_id;


--
-- Name: soldier_attrb; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.soldier_attrb (
    soldier_attrb_id integer NOT NULL,
    callsign character varying(50) NOT NULL,
    user_id integer
);


ALTER TABLE public.soldier_attrb OWNER TO postgres;

--
-- Name: soldier_attrb_soldier_attrb_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.soldier_attrb_soldier_attrb_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.soldier_attrb_soldier_attrb_id_seq OWNER TO postgres;

--
-- Name: soldier_attrb_soldier_attrb_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.soldier_attrb_soldier_attrb_id_seq OWNED BY public.soldier_attrb.soldier_attrb_id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    user_id integer NOT NULL,
    user_name character varying(255) NOT NULL,
    user_surname character varying(255) NOT NULL,
    password character varying(255) NOT NULL,
    email character varying(255) NOT NULL,
    role character varying(50) NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_user_id_seq OWNER TO postgres;

--
-- Name: users_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;


--
-- Name: volunteer_attrb; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.volunteer_attrb (
    volunteer_attrb_id integer NOT NULL,
    status character varying(10),
    user_id integer,
    CONSTRAINT volunteer_attrb_status_check CHECK (((status)::text = ANY ((ARRAY['active'::character varying, 'nonactive'::character varying])::text[])))
);


ALTER TABLE public.volunteer_attrb OWNER TO postgres;

--
-- Name: volunteer_attrb_volunteer_attrb_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.volunteer_attrb_volunteer_attrb_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.volunteer_attrb_volunteer_attrb_id_seq OWNER TO postgres;

--
-- Name: volunteer_attrb_volunteer_attrb_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.volunteer_attrb_volunteer_attrb_id_seq OWNED BY public.volunteer_attrb.volunteer_attrb_id;


--
-- Name: weapon; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.weapon (
    weapon_id integer NOT NULL,
    type character varying(50) NOT NULL,
    name character varying(255) NOT NULL,
    price numeric(10,2) NOT NULL,
    weight numeric(6,2) NOT NULL,
    user_id integer
);


ALTER TABLE public.weapon OWNER TO postgres;

--
-- Name: weapon_weapon_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.weapon_weapon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.weapon_weapon_id_seq OWNER TO postgres;

--
-- Name: weapon_weapon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.weapon_weapon_id_seq OWNED BY public.weapon.weapon_id;


--
-- Name: ammunition ammunition_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ammunition ALTER COLUMN ammunition_id SET DEFAULT nextval('public.ammunition_ammunition_id_seq'::regclass);


--
-- Name: inventory_ammunition inventory_ammunition_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inventory_ammunition ALTER COLUMN inventory_ammunition_id SET DEFAULT nextval('public.inventory_ammunition_inventory_ammunition_id_seq'::regclass);


--
-- Name: inventory_weapon inventory_weapon_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inventory_weapon ALTER COLUMN inventory_weapon_id SET DEFAULT nextval('public.inventory_weapon_inventory_weapon_id_seq'::regclass);


--
-- Name: requests request_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests ALTER COLUMN request_id SET DEFAULT nextval('public.requests_request_id_seq'::regclass);


--
-- Name: routes route_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routes ALTER COLUMN route_id SET DEFAULT nextval('public.routes_route_id_seq'::regclass);


--
-- Name: soldier_attrb soldier_attrb_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.soldier_attrb ALTER COLUMN soldier_attrb_id SET DEFAULT nextval('public.soldier_attrb_soldier_attrb_id_seq'::regclass);


--
-- Name: users user_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);


--
-- Name: volunteer_attrb volunteer_attrb_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.volunteer_attrb ALTER COLUMN volunteer_attrb_id SET DEFAULT nextval('public.volunteer_attrb_volunteer_attrb_id_seq'::regclass);


--
-- Name: weapon weapon_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.weapon ALTER COLUMN weapon_id SET DEFAULT nextval('public.weapon_weapon_id_seq'::regclass);


--
-- Data for Name: ammunition; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ammunition (ammunition_id, type, name, price, size, users_gender, user_id) FROM stdin;
\.


--
-- Data for Name: inventory_ammunition; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.inventory_ammunition (inventory_ammunition_id, ammunition_id, general_ammunition, storage_ammunition) FROM stdin;
\.


--
-- Data for Name: inventory_weapon; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.inventory_weapon (inventory_weapon_id, weapon_id, general_quantity, storage_quantity) FROM stdin;
\.


--
-- Data for Name: requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.requests (request_id, senter_soldier, receiver_admin, weapon_id, ammunition_id, quantity_requested, message, request_status) FROM stdin;
\.


--
-- Data for Name: routes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.routes (route_id, volunteer_id, weapon_id, ammunition_id, starting_point, destination_point, quantity_delivered, delivery_date) FROM stdin;
\.


--
-- Data for Name: soldier_attrb; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.soldier_attrb (soldier_attrb_id, callsign, user_id) FROM stdin;
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (user_id, user_name, user_surname, password, email, role) FROM stdin;
\.


--
-- Data for Name: volunteer_attrb; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.volunteer_attrb (volunteer_attrb_id, status, user_id) FROM stdin;
\.


--
-- Data for Name: weapon; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.weapon (weapon_id, type, name, price, weight, user_id) FROM stdin;
\.


--
-- Name: ammunition_ammunition_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ammunition_ammunition_id_seq', 1, false);


--
-- Name: inventory_ammunition_inventory_ammunition_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.inventory_ammunition_inventory_ammunition_id_seq', 1, false);


--
-- Name: inventory_weapon_inventory_weapon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.inventory_weapon_inventory_weapon_id_seq', 1, false);


--
-- Name: requests_request_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.requests_request_id_seq', 1, false);


--
-- Name: routes_route_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.routes_route_id_seq', 1, false);


--
-- Name: soldier_attrb_soldier_attrb_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.soldier_attrb_soldier_attrb_id_seq', 1, false);


--
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_user_id_seq', 1, false);


--
-- Name: volunteer_attrb_volunteer_attrb_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.volunteer_attrb_volunteer_attrb_id_seq', 1, false);


--
-- Name: weapon_weapon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.weapon_weapon_id_seq', 1, false);


--
-- Name: ammunition ammunition_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ammunition
    ADD CONSTRAINT ammunition_pkey PRIMARY KEY (ammunition_id);


--
-- Name: inventory_ammunition inventory_ammunition_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inventory_ammunition
    ADD CONSTRAINT inventory_ammunition_pkey PRIMARY KEY (inventory_ammunition_id);


--
-- Name: inventory_weapon inventory_weapon_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inventory_weapon
    ADD CONSTRAINT inventory_weapon_pkey PRIMARY KEY (inventory_weapon_id);


--
-- Name: requests requests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_pkey PRIMARY KEY (request_id);


--
-- Name: routes routes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routes
    ADD CONSTRAINT routes_pkey PRIMARY KEY (route_id);


--
-- Name: soldier_attrb soldier_attrb_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.soldier_attrb
    ADD CONSTRAINT soldier_attrb_pkey PRIMARY KEY (soldier_attrb_id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);


--
-- Name: volunteer_attrb volunteer_attrb_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.volunteer_attrb
    ADD CONSTRAINT volunteer_attrb_pkey PRIMARY KEY (volunteer_attrb_id);


--
-- Name: weapon weapon_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.weapon
    ADD CONSTRAINT weapon_pkey PRIMARY KEY (weapon_id);


--
-- Name: ammunition ammunition_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ammunition
    ADD CONSTRAINT ammunition_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- Name: inventory_ammunition inventory_ammunition_ammunition_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inventory_ammunition
    ADD CONSTRAINT inventory_ammunition_ammunition_id_fkey FOREIGN KEY (ammunition_id) REFERENCES public.ammunition(ammunition_id) ON DELETE CASCADE;


--
-- Name: inventory_weapon inventory_weapon_weapon_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inventory_weapon
    ADD CONSTRAINT inventory_weapon_weapon_id_fkey FOREIGN KEY (weapon_id) REFERENCES public.weapon(weapon_id) ON DELETE CASCADE;


--
-- Name: requests requests_ammunition_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_ammunition_id_fkey FOREIGN KEY (ammunition_id) REFERENCES public.ammunition(ammunition_id) ON DELETE CASCADE;


--
-- Name: requests requests_receiver_admin_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_receiver_admin_fkey FOREIGN KEY (receiver_admin) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- Name: requests requests_senter_soldier_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_senter_soldier_fkey FOREIGN KEY (senter_soldier) REFERENCES public.soldier_attrb(soldier_attrb_id) ON DELETE CASCADE;


--
-- Name: requests requests_weapon_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_weapon_id_fkey FOREIGN KEY (weapon_id) REFERENCES public.weapon(weapon_id) ON DELETE CASCADE;


--
-- Name: routes routes_ammunition_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routes
    ADD CONSTRAINT routes_ammunition_id_fkey FOREIGN KEY (ammunition_id) REFERENCES public.ammunition(ammunition_id) ON DELETE CASCADE;


--
-- Name: routes routes_volunteer_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routes
    ADD CONSTRAINT routes_volunteer_id_fkey FOREIGN KEY (volunteer_id) REFERENCES public.volunteer_attrb(volunteer_attrb_id) ON DELETE CASCADE;


--
-- Name: routes routes_weapon_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.routes
    ADD CONSTRAINT routes_weapon_id_fkey FOREIGN KEY (weapon_id) REFERENCES public.weapon(weapon_id) ON DELETE CASCADE;


--
-- Name: soldier_attrb soldier_attrb_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.soldier_attrb
    ADD CONSTRAINT soldier_attrb_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- Name: volunteer_attrb volunteer_attrb_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.volunteer_attrb
    ADD CONSTRAINT volunteer_attrb_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- Name: weapon weapon_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.weapon
    ADD CONSTRAINT weapon_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

