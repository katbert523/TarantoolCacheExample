1. Поднять контейнер тарантула 
	docker run --name mytarantool -p3301:3301 -d tarantool/tarantool
	
2. Перейти в консоль (в CLI): /opt/tarantool # console

3. Выполнить подготовительные команды:
	box.cfg{listen=3301}
	box.schema.space.create('examples',{id=999})
	box.space.examples:create_index('primary', {type = 'hash', parts = {1, 'unsigned'}})
	box.schema.user.grant('guest','read,write','space','examples')
	box.schema.user.grant('guest','read','space','_space')
	
4. В библиотеке подключить нугет progaudi.tarantool

5. Пилим кэш и радуемся)