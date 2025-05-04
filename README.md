

# 🛠️ Sistema de Gestión para Taller de Reparación de Electrodomésticos

Este sistema fue desarrollado en **Windows Forms con C# y SQL Server** para gestionar de manera eficiente las reparaciones de electrodomésticos en un taller. Permite registrar equipos (como televisores, parlantes, microondas, pavas eléctricas, entre otros), gestionar clientes, hacer seguimientos de trabajos, presupuestos, estados de reparación, emitir comprobantes e incluso calcular ganancias semanales.

## 📌 Funcionalidades Principales

- **Ingreso de clientes y equipos:**  
  Un formulario donde el usuario registra datos del cliente y del equipo a reparar. Se puede elegir la categoría del equipo (televisor, parlante, etc.), y según la categoría, se habilitan campos específicos (por ejemplo, si trae control, cable o base).

- **Almacenamiento en base de datos:**  
  Toda la información registrada se guarda en una base de datos SQL Server.

- **Comprobante de trabajo:**  
  Luego del registro, se genera un comprobante en formato imprimible y se guarda automáticamente en una carpeta local para su posterior entrega al cliente.

- **Gestión de trabajos (CRUD):**  
  En otro formulario se pueden:
  - Buscar trabajos por ID, nombre del cliente o equipo.
  - Editar cualquier dato registrado (cliente, equipo, presupuesto, estado, etc.).
  - Cambiar el **estado del trabajo**: en reparación, listo para entregar, entregado.
  - Agregar el **presupuesto** y el **monto final** del arreglo.

- **Gestión de entregas y ganancias:**  
  Cuando un trabajo es marcado como entregado, se registra la **fecha de entrega** y se transfiere a un formulario de **ganancias semanales**, donde se agrupan todos los trabajos entregados de lunes a domingo con sus respectivos ingresos.

## 🧰 Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** Windows Forms
- **Base de Datos:** SQL Server
- **Generación de comprobantes:** Impresión a partir de los datos guardados (puede incluir uso de `PrintDocument` o exportación a PDF)
- **Almacenamiento local de archivos:** Carpeta en disco local

## 🖼️ Imagenes del Proyecto

<p align="center">
  <img src="https://github.com/user-attachments/assets/e3fbf5b6-68f9-4364-9d68-e9859f7cc6f2" width="400" />
  <img src="https://github.com/user-attachments/assets/0d38279c-c67b-4d69-86a2-a149c49108ee" width="400" />
  <img src="https://github.com/user-attachments/assets/bb1c1973-863f-4d8a-86fc-a15415f9e416" width="400" />
  <img src="https://github.com/user-attachments/assets/812075c3-6b73-4bd3-a5e7-9494dc4922f3" width="400" />
  <img src="https://github.com/user-attachments/assets/e71a0d4e-c6cd-4bbd-8fcd-f8554f687414" width="400" />
  <img src="https://github.com/user-attachments/assets/48e4be2f-926f-40a7-add9-ab079862f802" width="400" />
  <img src="https://github.com/user-attachments/assets/1a71a1e3-9ba7-4863-8219-f447ca5e21e8" width="400" />
  <img src="https://github.com/user-attachments/assets/8110fca9-f4d0-4f25-8904-f5c223dc7bf3" width="400" />
  <img src="https://github.com/user-attachments/assets/6fa72f7f-ad27-4dfa-8817-5a453abc7bea" width="400" />
</p>



## 🎬 Demostración en video

[VIDEO-PROYECTO.zip](https://github.com/user-attachments/files/19786402/VIDEO-PROYECTO.zip)





## 🖥️ Instalación y uso

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/nombre-del-repo.git

## 😀 LOGO DEL PROYECTO


![Logo](https://github.com/user-attachments/assets/cb1479e8-3bbd-451c-96dd-9ef9814980ea)
