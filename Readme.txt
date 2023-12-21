========================Arquitectura usada===============================

Se está haciendo uso de Clean Architecture, la cuál se estructura en las siguientes capas:

-Infrastracture: Es la capa que maneja todas las conexiones externas, como bases de datos y las declaraciones 
 de servicios externos como el de "https://mockapi.io/".

-Core: Es la capa donde se definen todos los casos de usos del negocio y al mismo tiempo, las entidades que juegan
 un rol en dicho negocio. Cabe destacar que esta capa es totalmente independiente, es decir, no depende de ninguna otra
 capa en la aplicación, lo cual permite otorgar más escalabilidad a largo plazo, ya que si por ejemplo, cambiamos el motor de
 base de datos, la lógica del negocio no se ve afectada.

-API: Es la capa frontal y es donde está creada el API Rest. En esta capa, se hacen los llamados a los repositorios de infrastracture
 y de los casos de uso de Core.

=======================Versión del .NET======================================

NET 7

========================Motor de base de datos=================================

SQL Server


========================Patrones y/o principios SOLID usados==================

Principalmente se usa la inversión de dependencias a través de la inyección de dependencias.


=========================Pasos para levantar el proyecto localmente============

1) Restaurar el backup de la base de datos que se encuentra en la carpeta "Database".
2) Asegurarse que está establecido como proyecto de inicio "TektonLabs.API" y correr con http no con https.
3) Una vez que se abra el navegador, cambiar la url http://localhost:5265/swagger/index.html por http://localhost:5265/api.tektonlabs.com/products


=========================Sobre la documentación del API con Swagger=================

La documentación fue hecha en el editor de https://editor.swagger.io/, esto generó un archivo .yaml. Entonces,
para ver la documentación, lo que hay que hacer es ir a la web especificada anteriormente e importar el archivo "openapi.yaml", en cual se encuentra en
la siguiente ruta: NET 7\TektonLabs.API.
