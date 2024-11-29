

# **Restaurante Roko - Sistema de Gestión**

**"Desarrollo e Implementación de un Sistema para mejorar la eficiencia y ventas del Restaurante Roko"**! Este sistema fue desarrollado para optimizar la **gestión operativa** y mejorar la **atención al cliente**, incrementando la eficiencia y potenciando las ventas del restaurante.

---
## Autor

- [@Jonathan03R](https://github.com/Jonathan03R)
  
---


## Clona el repositorio con


```bash
  git clone https://github.com/Jonathan03R/Restarurante-Roko.git
```
    


## **Descripción del Proyecto**

Este sistema fue creado en **Visual Studio** utilizando **Visual Basic**, siguiendo una arquitectura de **n-capas**. La estructura modular facilita su mantenimiento y escalabilidad, garantizando un desempeño óptimo para las operaciones del restaurante. 

El sistema está diseñado para manejar las operaciones críticas del restaurante, como la **gestión de mesas**, **generación de comprobantes de pago**, y **administración de empleados y roles**. Además, utiliza **transacciones optimizadas** para garantizar la integridad de los datos y cuenta con un sistema de **seguridad mejorada** mediante el uso de contraseñas encriptadas.

---

## **Principales Funcionalidades**

### **1. Gestión de Clientes**
- Registro y mantenimiento de datos de clientes.
- Identificación de **clientes frecuentes** para agilizar la emisión de comprobantes.
- Mejora la experiencia del cliente al reducir tiempos en facturación y pedidos.

### **2. Gestión de Mesas**
- Administración del estado de las mesas en tiempo real:
  - **Ocupadas**
  - **Desocupadas**
  - **Atendidas**
- Asignación dinámica del responsable de atención para cada mesa.

### **3. Generación de Comprobantes de Pago**
- Creación rápida y automática de:
  - **Boletas**
  - **Facturas**
- Registro detallado de cada pago asociado a pedidos y clientes.

### **4. Gestión de Empleados y Roles**
- Mantenimiento de datos de empleados y usuarios del sistema.
- Asignación de **roles** y permisos personalizados según funciones específicas.
- Implementación de un **sistema de inicio de sesión seguro**, con contraseñas encriptadas para proteger los datos.

### **5. Seguridad y Eficiencia**
- Uso de **transacciones optimizadas** para garantizar consistencia en operaciones críticas.
- Registro detallado del historial de actividades para trazabilidad.

---

## **Estructura del Proyecto**

El proyecto está organizado en capas siguiendo el patrón **n-capas**, que incluye:

### **1. Capa de Presentación**
- Interfaz gráfica amigable y eficiente.
- Formularios organizados en módulos funcionales:
  - **Finanzas**: Gestión de comprobantes y pagos.
  - **Operaciones**: Manejo de pedidos y mesas.
  - **Soporte**: Administración de clientes, empleados y roles.
  - **Login**: Acceso seguro al sistema.

### **2. Capa de Aplicación**
- Procesamiento de las operaciones entre la interfaz y la lógica de negocio.
- Coordinación de las solicitudes entre las capas.

### **3. Capa de Dominio**
- Modelos que representan las entidades principales del sistema, tales como:
  - Cliente, Mesa, Pedido, Boleta, Factura, Empleado, entre otros.
- Contiene la lógica del negocio central.

### **4. Capa de Persistencia**
- Gestión directa de la base de datos mediante consultas y procedimientos almacenados.
- Soporta operaciones complejas como:
  - Manejo de transacciones.
  - CRUD (Crear, Leer, Actualizar, Eliminar) de datos para clientes, empleados, mesas y pedidos.

---

## **Tecnologías Utilizadas**
- **Visual Studio**: IDE principal para el desarrollo.
- **Visual Basic**: Lenguaje de programación.
- **SQL Server**: Motor de base de datos para la gestión de información.

---

## **Objetivo del Proyecto**

Este sistema fue desarrollado con el propósito de:
1. **Optimizar la eficiencia** en la atención y operación del restaurante.
2. **Aumentar las ventas** mediante una mejor experiencia para los clientes.
3. Facilitar la gestión del restaurante mediante herramientas integradas y seguras.

---

## Capturas del proyecto
###login

---
![App Screenshot](https://github.com/user-attachments/assets/57e95134-f7f2-41de-aa9c-1185e5d0a71c)

---

![image](https://github.com/user-attachments/assets/1fc27c60-7940-4580-9f90-b27630d13fe4)

---

![image](https://github.com/user-attachments/assets/3eefd352-99e8-487b-aa1c-49f6e5e45838)

---

### mesa ocupada

![image](https://github.com/user-attachments/assets/a0521b18-8fa0-46f2-87ec-a265b01a0812)

### al hacer click en una mesa ocupada:
se podra agregar mas pedidos o finalizar el pedido

![image](https://github.com/user-attachments/assets/8b9d80d4-bf1c-437d-a9b2-7595af1e6eae)


### Opciones para fializar pedido:
Se podra elegir un cliente recurrente para futuras promociones o agregar un nuevo cliente si es necesario.
si en caso desea factura solo se solicitara el RUC y la empresa:

![image](https://github.com/user-attachments/assets/e3347826-9619-4d76-a31f-84b417e56c81)

![image](https://github.com/user-attachments/assets/eb51e89f-3c61-4fa1-9e1d-f28422091f01)

### Generar la boleta
![image](https://github.com/user-attachments/assets/6fbb6794-f816-4bcf-b5cd-8014608e307d)

### Generar la Factura
![image](https://github.com/user-attachments/assets/aa9cc5d2-f3f8-4216-845b-26e988338c71)

### Administracion de Menú:

![image](https://github.com/user-attachments/assets/49bcf72a-602f-4ae8-bbf6-f016bb4ff0c2)

### opciones y funcionalidades

![image](https://github.com/user-attachments/assets/03d5517c-3fd3-4935-9dfb-cf2c7101da65)

### Finanzas 
![image](https://github.com/user-attachments/assets/e6372a9b-f6fc-4efd-8069-1d3886f23ce5)




## Muestra de la arquitectura de las Carpetas

```Restaurante-Roko/
│
├── CapaPresentacion/
│   ├── Formularios/
│   │   ├── Finanzas.vb
│   │   ├── Operaciones.vb
│   │   ├── Soporte.vb
│   │   ├── Login.vb
│   │   └── PaginaPrincipal.vb
│   ├── App.config
│   └── packages.config
│
├── CapaAplicacion/
│   ├── ProcesarPagoServicio.vb
│   ├── ProcesarPedidoServicio.vb
│   ├── ProcesarReservacionesServicio.vb
│   ├── ProcesoGestionarEmpleadosServicios.vb
│   ├── ProcesoGestionarMenuServicios.vb
│   └── ProcesoGestionarMesasServicio.vb
│
├── CapaDominio/
│   ├── Entidades/
│   │   ├── Boleta.vb
│   │   ├── Cliente.vb
│   │   ├── DetallePedido.vb
│   │   ├── Documento.vb
│   │   ├── Empleado.vb
│   │   ├── Factura.vb
│   │   ├── HistorialPedido.vb
│   │   ├── Menu.vb
│   │   ├── Mesa.vb
│   │   ├── MesaReserva.vb
│   │   ├── Pago.vb
│   │   ├── Pedido.vb
│   │   └── RolPermiso.vb
│
├── CapaPersistencia/
│   ├── ModuloPrincipal/
│   │   ├── Datos2_GrupoN_BaseDeDatosRestauranteRoko.sql
│   │   └── ModuloSistema.vb
│   ├── ModuloSecundarios/
│   │   ├── ClienteSQL.vb
│   │   ├── CodigosSQL.vb
│   │   ├── ComprobantePagoSQL.vb
│   │   ├── DetallePedidoSQL.vb
│   │   ├── DocumentoSQL.vb
│   │   ├── EmpleadoSQL.vb
│   │   ├── HistorialSQL.vb
│   │   ├── MenuSQL.vb
│   │   ├── MesaSQL.vb
│   │   ├── PagoSQL.vb
│   │   ├── PedidoSQL.vb
│   │   ├── ReservaSQL.vb
│   │   └── RolPermisoSQL.vb
│
└── assets/
    ├── iconos/
    │   └── pdf.ico
    ├── imagenes/
    │   ├── pdf.png
    │   └── Restaurante.jpg
    └── otros_archivos/

```



## **Conclusión**

El sistema desarrollado para el Restaurante “Roko” no solo mejora la eficiencia operativa, sino que también transforma la experiencia del cliente, convirtiendo cada visita en una experiencia única. ¡Un paso firme hacia la modernización y el éxito continuo del restaurante!

---
