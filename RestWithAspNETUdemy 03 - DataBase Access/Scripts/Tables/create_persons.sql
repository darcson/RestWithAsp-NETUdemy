use rest_with_asp_net_udemy

create table persons
(
	Id int null default null,
	FirstName varchar(50),
	LastName varchar(50),
	Address  varchar(50),
	Gender varchar(10) check(Gender in('Male', 'Female'))
)