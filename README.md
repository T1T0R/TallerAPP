

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

## 🎬 Demostración en video

[VIDEO-PROYECTO.zip](https://github.com/user-attachments/files/19786402/VIDEO-PROYECTO.zip)





## 🖥️ Instalación y uso

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/nombre-del-repo.git

## 😀 LOGO DEL PROYECTO

![Logo](https://github.com/user-attachments/assets/d77ff42a-b9ed-4698-be0b-8e1fc058136f)


