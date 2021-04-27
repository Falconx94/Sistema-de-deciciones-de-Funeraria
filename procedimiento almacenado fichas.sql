create procedure fichasdepago
@idcliente tinyint,
@idpaquete tinyint,
@fecha datetime
as
begin
	select c.nombre, c.domicilio,
	p.nombre,p.descripcion,p.precio, 
	r.enganche, r.mensualidad, r.fecha 
	from recibos r
	join paquetes p on r.idpaquete = p.idpaquete
	join clientes c on r.idcliente = c.idcliente
	where r.idcliente = @idcliente and r.idpaquete = @idpaquete
end


