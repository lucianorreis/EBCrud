import express from 'express';
import 'dotenv/config';

import conection from '../conection';

const app = express();
// const path = require("path");
const PORT = 3000;
const url = 'http://localhost'

app.use(express.json());

app.get('/', (req, res) => {
    //* Executamos a query para o banco de dados

    conection.query('SELECT * FROM Arranchamento', (err, result) => {
        res.send(result)
    })
});

app.listen(PORT, () => {
    console.log(`Servidor está executando na porta ${url}:${PORT}`);
});