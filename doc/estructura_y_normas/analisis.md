# Análise: Requirimentos do sistema

## Descrición xeral

## Casos de uso

```mermaid
flowchart LR
    %% Definición do actor usando un icono
    Usuario((fa:fa-user Usuario))

    subgraph S["Funcionalidades do xogo breakout"]
        %% Definición dos casos de uso (forma de píldora/óvalo)
        GolpearPelota([GolpearPelota])
        Paredes([Paredes])
        Bloques([Bloques])

    



    end

    
    %% Relacións
    Usuario --> GolpearPelota
    GolpearPelota --> Paredes
    GolpearPelota --> Bloques




```

## Funcionalidades

### FUNCIONAIS

- Añadir funcionalidades novas e melloradas ao xogo breakout.
- Correción de bugs.

### NON FUNCIONAIS

- Soporte para diferentes resolucións de pantalla.
- Soporte para diferentes idiomas.

## Tipos de usuarios

- Usuario: pode interactuar usando a pa coa pelota do xogo
