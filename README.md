# CRUD lista de personas con win forms

Proyecto CRUD con WinForms a puro Sql sin Entity Framework en la cual mediante un GridView mostramos una lista de personas con nombre y apellido.

El programa permite agregar nuevas personas, modificar sus datos, eliminar y probar la conexion que a su vez actualiza la lista.

![crudwf1](https://user-images.githubusercontent.com/102115164/168941749-84c44d19-baa1-40d4-b85f-8d89d33439b3.png)

![crudwf2](https://user-images.githubusercontent.com/102115164/168941766-cb286fec-3fb2-43cc-9cfd-042f95e74854.png)

![crudwf5](https://user-images.githubusercontent.com/102115164/168942177-5b91affc-539a-4213-b2c7-5547693fce90.png)


Agregar y Editar estan vinculados mediante el mismo formulario, se van a distinguir solo por si esta seleccionado un dato de la lista, dado que 
el boton editar permite traer los datos al nuevo dialogo para modificarlos.

![crudwf3](https://user-images.githubusercontent.com/102115164/168941782-c141a6ec-5982-4626-a422-c78295bc3381.png)

![crudwf4](https://user-images.githubusercontent.com/102115164/168941796-bf8a29be-7359-481b-a152-d3258a57c28b.png)

Como dijimos anteriormente el boton probar conexion no solo sirve para verificar que se haya hecho un enlace con la base de datos y que no 
haya errores, sino tambien permite actulizar el estado de la lista si es que se modifico la base de datos por fuera de este sistema.

Tecnologias utilizadas: Lenguaje C#, WinForms, SqlServer y Visual Studio



