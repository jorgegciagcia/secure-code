# CONFIGURE SONARQUBE

## CREATE DOCKER

Ejecutar el siguiente comando en linux shell:

```sh
sudo docker run -d --name sonarqube-custom -p 9000:9000 sonarqube:10.6-community
```
Las credenciales por defecto son: `admin:admin`

## CREATE TOKEN DE AUTENTICACIÓN

1. Una vez logado, pulsar en el icono del usuario A y ver *My Account*

![alt text](image.png)

2. En la pantalla de administración pulsar en la pestaña *Security*

![alt text](image-1.png)

3. Generar un token llamado sonarlint del tipo usertoken y con una caducidad de 30 días. Pulsar el botón Generate

![alt text](image-2.png)

4. Copiar el token generado y copiarlo en la configuración de sonarlint al añadir una conexión sonarqube:

![alt text](image-3.png)

## CREAR PERFILES DE CALIDAD EN SONARQUBE

1. Navegar a QualityProfiles, Seleccionar C# y pulsar en el botón de menús: 

![alt text](image-4.png)

2. Pulsar en extend y seleccionar le nombre c#-extender

![alt text](image-5.png)

3. Se abrirá la venta de configuración del perfil de calidad c#-extender y se deberá pulsar en el botón activate more
![alt text](image-6.png)

## CONFIGURAR LAS REGLAS DEL PERFIL c#-extender

![alt text](image-7.png)

## CONFIGURAR UN PROYECTO

1. Ir a la pestaña Projects y pulsar en *Create a local project*

![alt text](image-8.png)

2. Establecer el nombre al proyecto y pulsar el botón *next*

![alt text](image-9.png)

3. Para el modo demostración, seleccionar *Use the global setting* y pulsar en create project

![alt text](image-10.png)

4. Antes de lanzar análisis, se recomeinda seleccionar el Qyuality Profile:

![alt text](image-15.png)
![alt text](image-16.png)


5. En al pantalla *Analysiis Method* Seleccionar *Locally*

![alt text](image-11.png)

6. Generar un token llamado project_token

![alt text](image-12.png)

7. Copiar el contenido del token y pulsar continue

8. Seleccionar el tipo de análisis. En este caso se seleccionará el .NET

![alt text](image-13.png)

9. Seleccionar .NET Core y almacenar los comandos que propone

![alt text](image-14.png)


10. Para que funcione con sonar lint, añadir a la isntancia configurada previamente de *sonarqube* el proyecto que se acaba de crear:

![alt text](image-17.png)
![alt text](image-18.png)

Pulsar en *Share configuration* 

![alt text](image-19.png)

**NOTAS**: *Para visualizar las vulnerabilidades y malas prácticas de seguriad, visualizar la pestaña SECUIRRTY HOSTPOTS de sonarlint*

![alt text](image-20.png)

![alt text](image-21.png)

