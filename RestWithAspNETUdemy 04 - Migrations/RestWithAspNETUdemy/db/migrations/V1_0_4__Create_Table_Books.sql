use rest_with_asp_net_udemy
if not exists(select object_id from sys.tables where Name = 'Books')
create table Books
(
	Id bigint primary key identity,
	TextKey varchar(150) not null,
	Author varchar(100),
	LaunchDate datetime not null,
	Price numeric(16, 6),
	Title varchar(200)
)
