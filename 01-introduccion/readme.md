# Seguridad en el software

## Introducción a la seguridad del desarrollo seguro de software

### Definición de seguridad en el software

La seguridad del software es el concepto de implementar mecanismos en la construcción de la seguridad para ayudarla a permanecer funcional (o resistente) a los ataques. Esto significa que una pieza de software se somete a pruebas de seguridad antes de salir al mercado para comprobar su capacidad para resistir ataques maliciosos.

La idea detrás de la seguridad del software es crear software que sea seguro desde el principio sin tener que agregar elementos de seguridad adicionales para agregar capas adicionales de seguridad (aunque en muchos casos, esto todavía sucede). El siguiente paso es enseñar a los usuarios a usar el software de la manera correcta para evitar ser propensos o estar expuestos a ataques.

La seguridad del software es fundamental porque un ataque de malware puede causar un daño extremo a cualquier pieza de software al tiempo que compromete la integridad, la autenticación y la disponibilidad. Si los programadores tienen esto en cuenta en la etapa de programación y no después, el daño puede detenerse antes de que comience.

La seguridad de la TI es el proceso de proteger todos los datos de una entidad en particular, tanto electrónicos como físicos. A menudo, la seguridad informática y la ciberseguridad se consideran cercanas entre sí. Si bien esto es cierto, la seguridad informática tiende a ser más amplia y no solo se centra en la actividad delictiva en línea destinada a causar daños.

Hay cuatro tipos principales de seguridad de TI que es importante comprender cuando se trata de seguridad del software.

- *Seguridad de red:* la seguridad entre diferentes dispositivos ubicados en la misma red. En este caso, tanto la seguridad del software como la del hardware son importantes. Al proteger una red, las empresas buscan asegurarse de que su red no se utilice de forma malintencionada.
- *Seguridad de punto final:* en esta situación, la seguridad se centra en los dispositivos utilizados. Esto significa que las computadoras portátiles, teléfonos, computadoras, tabletas y otros dispositivos son seguros (nuevamente, tanto el software como el hardware) para evitar la entrada de usuarios no deseados. Esto a menudo implica varios métodos de cifrado, controles de usuario y, por supuesto, seguridad del software.
- *Seguridad en Internet:* esto es lo que comúnmente se conoce como ciberseguridad y se ocupa del tránsito y uso de la información. Los ataques de ciberseguridad ocurren cuando se intercepta información y, por lo tanto, se suelen utilizar varias capas de cifrado y autenticación para detener estos ataques.
- *Seguridad en la nube:* la seguridad en la nube gira en torno a reducir los riesgos de seguridad del software dentro de la nube. Algunos de los conceptos de seguridad en la nube se superponen con las otras formas de seguridad enumeradas aquí, al tener que proteger las transferencias de datos y los dispositivos en la misma red.

### Principios básicos de la seguridad

Según la norma ENS, los principios básicos de la seguridad son:

- Arquitectura segura
- Autenticación
- Autorización
- Gestión de sesiones
- Validación de datos de entrada y salida
- Gestión de errores
- Criptografía
- Gestión segura de archivos
- Seguriad en las comunicaciones

## Amenazas y vulnerabilidades comunes

### Tipos de amenazas

1. Ataques de ingenierái social
2. Ramsoware
3. Ataques a la cadena de suministro
4. Ataques impulsados por la IA
5. Ataques basados en contraseñas
6. Ataques IoT
7. Vulnerabilidades en la nube
8. Ataques de vulneraación de correos electrónicos empresariales
9. DDoS
10. Filtraciones y violaciones de datos

### OWASP Top 10

- *A01:2021 - Pérdida de Control de Acceso* sube de la quinta posición a la categoría con el mayor riesgo en seguridad de aplicaciones web; los datos proporcionados indican que, en promedio, el 3,81% de las aplicaciones probadas tenían una o más Common Weakness Enumerations (CWEs) con más de 318.000 ocurrencias de CWEs en esta categoría de riesgo. Las 34 CWEs relacionadas con la Pérdida de Control de Acceso tuvieron más apariciones en las aplicaciones que cualquier otra categoría.
- *A02:2021 - Fallas Criptográficas* sube una posición ubicándose en la segunda, antes conocida como A3:2017-Exposición de Datos Sensibles, que era más una característica que una causa raíz. El nuevo nombre se centra en las fallas relacionadas con la criptografía, como se ha hecho implícitamente antes. Esta categoría frecuentemente conlleva a la exposición de datos confidenciales o al compromiso del sistema.
- *A03:2021 - Inyección* desciende hasta la tercera posición. El 94% de las aplicaciones fueron probadas con algún tipo de inyección y estas mostraron una tasa de incidencia máxima del 19%, promedio de 3.37%, y las 33 CWEs relacionadas con esta categoría tienen la segunda mayor cantidad de ocurrencias en aplicaciones con 274.000 ocurrencias. El Cross-Site Scripting, en esta edición, forma parte de esta categoría de riesgo.
- *A04:2021 - Diseño Inseguro* nueva categoría para la edición 2021, con un enfoque en los riesgos relacionados con fallas de diseño. Si realmente queremos madurar como industria, debemos "mover a la izquierda" del proceso de desarrollo las actividades de seguridad. Necesitamos más modelos de amenazas, patrones y principios con diseños seguros y arquitecturas de referencia. Un diseño inseguro no puede ser corregida con una implementación perfecta debido a que, por definición, los controles de seguridad necesarios nunca se crearon para defenderse de ataques específicos.
- *A05:2021 - Configuración de Seguridad Incorrecta* asciende desde la sexta posición en la edición anterior; el 90% de las aplicaciones se probaron para detectar algún tipo de configuración incorrecta, con una tasa de incidencia promedio del 4,5% y más de 208.000 casos de CWEs relacionadas con esta categoría de riesgo. Con mayor presencia de software altamente configurable, no es sorprendente ver qué esta categoría ascendiera. El A4:2017-Entidades Externas XML(XXE), ahora en esta edición, forma parte de esta categoría de riesgo.
- *A06:2021 - Componentes Vulnerables y Desactualizados* antes denominado como Uso de Componentes con Vulnerabilidades Conocidas, ocupa el segundo lugar en el Top 10 de la encuesta a la comunidad, pero también tuvo datos suficientes para estar en el Top 10 a través del análisis de datos. Esta categoría asciende desde la novena posición en la edición 2017 y es un problema conocido que cuesta probar y evaluar el riesgo. Es la única categoría que no tiene ninguna CVE relacionada con las CWEs incluidas, por lo que una vulnerabilidad predeterminada y con ponderaciones de impacto de 5,0 son consideradas en sus puntajes.
- *A07:2021 - Fallas de Identificación y Autenticación* previamente denominada como Pérdida de Autenticación, descendió desde la segunda posición, y ahora incluye CWEs que están más relacionadas con fallas de identificación. Esta categoría sigue siendo una parte integral del Top 10, pero el incremento en la disponibilidad de frameworks estandarizados parece estar ayudando.
- *A08:2021 - Fallas en el Software y en la Integridad de los Datos* es una nueva categoría para la edición 2021, que se centra en hacer suposiciones relacionadas con actualizaciones de software, los datos críticos y los pipelines CI/CD sin verificación de integridad. Corresponde a uno de los mayores impactos según los sistemas de ponderación de vulnerabilidades (CVE/CVSS, siglas en inglés para Common Vulnerability and Exposures/Common Vulnerability Scoring System). La A8:2017-Deserialización Insegura en esta edición forma parte de esta extensa categoría de riesgo.
- *A09:2021 - Fallas en el Registro y monitorización* previamente denominada como A10:2017-Registro y monitorización Insuficientes, es adicionada desde el Top 10 de la encuesta a la comunidad (tercer lugar) y ascendiendo desde la décima posición de la edición anterior. Esta categoría se amplía para incluir más tipos de fallas, es difícil de probar y no está bien representada en los datos de CVE/CVSS. Sin embargo, las fallas en esta categoría pueden afectar directamente la visibilidad, las alertas de incidentes y los análisis forenses.
- *A10:2021 - Falsificación de Solicitudes del Lado del Servidor* es adicionada desde el Top 10 de la encuesta a la comunidad (primer lugar). Los datos muestran una tasa de incidencia relativamente baja con una cobertura de pruebas por encima del promedio, junto con calificaciones por encima del promedio para la capacidad de explotación e impacto. Esta categoría representa el escenario en el que los miembros de la comunidad de seguridad nos dicen que esto es importante, aunque no está visualizado en los datos en este momento.

