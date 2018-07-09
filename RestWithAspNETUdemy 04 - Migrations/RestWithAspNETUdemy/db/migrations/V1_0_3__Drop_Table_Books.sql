use rest_with_asp_net_udemy
if exists(select object_id from sys.tables where Name = 'Books')
drop table Books
