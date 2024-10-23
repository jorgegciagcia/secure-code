# KNOWLEDGE

## AUTENTICACIÓN EN WINDOWS

### COMO FUNCIONA NTLM
```mermaid
sequenceDiagram
    participant C as Cliente
    participant S as Servidor
    participant D as Controlador de Dominio

    C->>S: Solicitar acceso al recurso
    S-->>C: Retornar desafío (Challenge)
    C->>C: Crear hash de contraseña (con el desafío)
    C->>S: Enviar respuesta (Response)
    S->>D: Verificar respuesta
    D-->>S: Confirmar autenticación
    S-->>C: Acceso concedido
```

**Descripción**

1. Cliente (C) solicita acceso a un recurso en el Servidor (S).
2. Servidor (S) responde al cliente con un desafío (Challenge).
3. Cliente (C) crea un hash de la contraseña utilizando el desafío recibido.
4. Cliente (C) envía la respuesta (Response) al servidor.
5. Servidor (S) verifica la respuesta con el Controlador de Dominio (D).
6. Controlador de Dominio (D) confirma la autenticación del cliente.
7. Servidor (S) concede acceso al cliente.

### COMO FUNCIONA KERBEROS

```mermaid
sequenceDiagram
    participant C as Cliente
    participant K as Controlador de Dominio
    participant S as Servicio

    C->>K: Solicitar TGT (Credenciales)
    K-->>C: Enviar TGT
    C->>K: Solicitar Ticket de Servicio (TGT)
    K-->>C: Enviar Ticket de Servicio
    C->>S: Solicitar acceso (Ticket de Servicio)
    S->>K: Verificar Ticket de Servicio
    K-->>S: Confirmar Ticket válido
    S-->>C: Acceso concedido
```

**Descripción**

1. Cliente (C) solicita un Ticket Granting Ticket (TGT) al Controlador de Dominio (K) enviando sus credenciales.
2. Controlador de Dominio (K) responde al cliente con el TGT.
3. El cliente utiliza el TGT para solicitar un Ticket de Servicio al Controlador de Dominio (K).
4. Controlador de Dominio (K) envía de vuelta el Ticket de Servicio.
5. El cliente envía el Ticket de Servicio al Servicio (S) para solicitar acceso.
6. Servicio (S) verifica el Ticket de Servicio con el Controlador de Dominio (K).
7. Controlador de Dominio (K) confirma que el ticket es válido.
8. Servicio (S) concede acceso al cliente

## SSO

### GENÉRICO

```mermaid
sequenceDiagram
    participant U as Usuario
    participant IdP as Proveedor de Identidad
    participant A1 as Aplicación 1
    participant A2 as Aplicación 2

    U->>A1: Solicitar acceso
    A1-->>U: Redirigir a IdP
    U->>IdP: Ingresar credenciales
    IdP-->>U: Confirmar autenticación (Token)
    U->>A1: Enviar token
    A1-->>U: Acceso concedido

    U->>A2: Solicitar acceso
    A2-->>U: Redirigir a IdP
    U->>IdP: Enviar token
    IdP-->>A2: Confirmar autenticación
    A2-->>U: Acceso concedido
```

**Descripción**

1. Usuario (U) solicita acceso a Aplicación 1 (A1).

2. Aplicación 1 (A1) redirige al usuario al Proveedor de Identidad (IdP) para autenticación.

3. Usuario (U) ingresa sus credenciales en el IdP.

4. Proveedor de Identidad (IdP) confirma la autenticación y envía un token al usuario.

5. Usuario (U) envía el token a Aplicación 1 (A1).

6. Aplicación 1 (A1) concede acceso al usuario.

7. Usuario (U) solicita acceso a Aplicación 2 (A2).

8. Aplicación 2 (A2) redirige al usuario al Proveedor de Identidad (IdP).

9. Usuario (U) envía el token al IdP.

10. Proveedor de Identidad (IdP) confirma la autenticación de nuevo.

11. Aplicación 2 (A2) concede acceso al usuario.

### SAML

```mermaid
sequenceDiagram
    participant U as Usuario
    participant IdP as Proveedor de Identidad
    participant SP as Proveedor de Servicios
    participant A as Aplicación

    U->>SP: Solicitar acceso
    SP-->>U: Redirigir a IdP
    U->>IdP: Ingresar credenciales
    IdP-->>U: Confirmar autenticación (SAML Assertion)
    U->>SP: Enviar SAML Assertion
    SP->>IdP: Verificar SAML Assertion
    IdP-->>SP: Confirmar autenticación
    SP-->>U: Acceso concedido
    SP-->>A: Acceso concedido (opcional)
```

**Descripción**

1. Usuario (U) solicita acceso al Proveedor de Servicios (SP).
2. Proveedor de Servicios (SP) redirige al usuario al Proveedor de Identidad (IdP) para autenticación.
3. Usuario (U) ingresa sus credenciales en el IdP.
4. Proveedor de Identidad (IdP) confirma la autenticación y envía una SAML Assertion al usuario.
5. Usuario (U) envía la SAML Assertion al Proveedor de Servicios (SP).
6. Proveedor de Servicios (SP) verifica la SAML Assertion con el IdP.
7. Proveedor de Identidad (IdP) confirma la autenticación del usuario al SP.
8. Proveedor de Servicios (SP) concede acceso al usuario.

### OAUTH

```mermaid
sequenceDiagram
    participant U as Usuario
    participant C as Cliente (Aplicación)
    participant Auth as Servidor de Autorización
    participant R as Recurso Protegido

    U->>C: Solicitar acceso
    C->>U: Redirigir a Auth (con solicitud de autorización)
    U->>Auth: Ingresar credenciales
    Auth-->>U: Confirmar autenticación (código de autorización)
    U->>C: Enviar código de autorización
    C->>Auth: Solicitar token de acceso (con código)
    Auth-->>C: Enviar token de acceso
    C->>R: Acceder al recurso protegido (con token)
    R-->>C: Retornar recurso
```

**Descripción**

1. Usuario (U) solicita acceso a la Cliente (C) (aplicación).
2. Cliente (C) redirige al usuario al Servidor de Autorización (Auth) con la solicitud de autorización.
3. Usuario (U) ingresa sus credenciales en el Auth.
4. Servidor de Autorización (Auth) confirma la autenticación y envía un código de autorización al usuario.
5. Usuario (U) envía el código de autorización a la Cliente (C).
6. Cliente (C) solicita un token de acceso al Auth utilizando el código de autorización.
7. Servidor de Autorización (Auth) envía un token de acceso a la Cliente (C).
8. Cliente (C) utiliza el token de acceso para acceder al Recurso Protegido (R).
9. Recurso Protegido (R) retorna el recurso solicitado a la Cliente (C).

### OpenID

```mermaid
sequenceDiagram
    participant U as Usuario
    participant C as Cliente (Aplicación)
    participant IdP as Proveedor de Identidad

    U->>C: Solicitar acceso
    C->>U: Redirigir a IdP (con solicitud de autorización)
    U->>IdP: Ingresar credenciales
    IdP-->>U: Confirmar autenticación (código de autorización)
    U->>C: Enviar código de autorización
    C->>IdP: Solicitar token de acceso + ID token (con código)
    IdP-->>C: Enviar token de acceso + ID token
    C->>IdP: Verificar ID token
    IdP-->>C: Confirmar identidad + Información del usuario (nombre, email, grupos)
    C->>C: Acceder a la aplicación (con token)
```
**Descripción**

1. Usuario (U) solicita acceso a la Cliente (C) (aplicación).
2. Cliente (C) redirige al usuario al Proveedor de Identidad (IdP) con la solicitud de autorización.
3. Usuario (U) ingresa sus credenciales en el IdP.
4. Proveedor de Identidad (IdP) confirma la autenticación y envía un código de autorización al usuario.
5. Usuario (U) envía el código de autorización a la Cliente (C).
6. Cliente (C) solicita un token de acceso y un ID token al IdP utilizando el código de autorización.
7. Proveedor de Identidad (IdP) envía un token de acceso y un ID token a la Cliente (C).
8. Cliente (C) verifica el ID token con el IdP.
9. Proveedor de Identidad (IdP) confirma la identidad del usuario y proporciona información adicional (nombre, correo electrónico y grupos).
10. Cliente (C) accede a la aplicación utilizando el token.