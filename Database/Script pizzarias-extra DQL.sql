USE PIZZARIAS_FS

-- Selecionando todos os usuarios
SELECT * FROM USUARIOS

-- Selecionando todas as pizzarias
SELECT * FROM PIZZARIAS

-- Selecionando todas as pizzarias e suas categorias
SELECT * FROM PIZZARIAS AS P INNER JOIN CATEGORIAS AS C ON P.ID_CATEGORIA = C.ID