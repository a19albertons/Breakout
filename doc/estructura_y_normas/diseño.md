# Deseño

## Diagrama da arquitectura

### Diagrama de componentes

```mermaid
flowchart TB
    %% tu
    Cliente[Usuario]

    %% app
    subgraph O dispositivo do usuario
        subgraph Aplicación
            ui[UI]
            Backend[Backend]
        end
    end

    %% relacións
    Cliente --> |interactúa| ui
    ui <--> |intercambio de datos| Backend
    
```

### Diagrama de Despregamento
```mermaid
flowchart TD
    %% nodo
    Usuario[Usuario]
    subgraph O dispositivo/navegador do usuario
        subgraph Sistema operativo o navegador
            Aplicacion[Aplicación]
        end
    end

    %% relacións
    Usuario -->|usa| Aplicacion

```

## Diagrama de Base de Datos

Non aplica non existe un almacenado da puntuación máis alta acadada

## Diagrama de clases

Non aplica, non hai clases definidas no proxecto

## Deseño da interface de usuario

Intentar ser parecido ao breakout orixinal.