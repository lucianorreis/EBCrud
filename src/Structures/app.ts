import "dotenv/config";
import express from "express";
import conection from "../../conection"; // Ensure your database connection is correct

const app = express();
const PORT = 3000;
const url = "http://localhost";

app.use(express.json());

app.post("/", (req, res) => {
  // Validate request body
  const { password, email } = req.body;
  if (!password || !email) {
    return res.status(400).json({ error: "Password and email are required" });
  }

  // If validation passes, you can proceed with further logic (e.g., saving to the DB or something else)
  res
    .status(200)
    .json({ message: "Login information received", password, email });
});

app.get("/", (req, res) => {
  //* Executamos a query para o banco de dados
  conection.query("SELECT * FROM Arranchamento", (err, result) => {
    if (err) {
      console.error("Database query error:", err);
      return res.status(500).json({
        error: "An error occurred while fetching data from the database",
      });
    }

    // If the query is successful, send the result
    res.json(result);
  });
});

app.listen(PORT, () => {
  console.log(`Servidor está executando na porta ${url}:${PORT}`);
});
