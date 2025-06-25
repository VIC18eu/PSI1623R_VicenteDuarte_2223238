-- ===========================
-- Tabela: Utilizador
-- ===========================
CREATE TABLE Utilizador (
    Email         NVARCHAR(100)  NOT NULL PRIMARY KEY,
    Nome          NVARCHAR(100)  NOT NULL,
    PalavraPasse  NVARCHAR(255)  NOT NULL,
    Imagem        VARCHAR(MAX)   NULL
);

-- ===========================
-- Tabela: Farmacia
-- ===========================
CREATE TABLE Farmacia (
    Id         INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nome       NVARCHAR(100)  NOT NULL,
    Endereco   NVARCHAR(200)  NULL,
    Telefone   NVARCHAR(20)   NULL,
    Email      NVARCHAR(100)  NULL,
    DonoEmail  NVARCHAR(100)  NOT NULL,
    FOREIGN KEY (DonoEmail) REFERENCES Utilizador(Email)
);

-- ===========================
-- Tabela: Funcionario
-- ===========================
CREATE TABLE Funcionario (
    EmailUtilizador NVARCHAR(100)  NOT NULL,
    FarmaciaId      INT            NOT NULL,
    Categoria       NVARCHAR(50)   NULL,
    PRIMARY KEY (EmailUtilizador, FarmaciaId),
    FOREIGN KEY (EmailUtilizador) REFERENCES Utilizador(Email),
    FOREIGN KEY (FarmaciaId)      REFERENCES Farmacia(Id)
);

-- ===========================
-- Tabela: Medicamento
-- ===========================
CREATE TABLE Medicamento (
    Id         INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nome       NVARCHAR(100)  NOT NULL,
    Descricao  NVARCHAR(255)  NULL,
    Categoria  NVARCHAR(100)  NULL,
    Fabricante NVARCHAR(100)  NULL,
    Dosagem    NVARCHAR(50)   NULL
);

-- ===========================
-- Tabela: Stock
-- ===========================
CREATE TABLE Stock (
    Id            INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MedicamentoId INT            NOT NULL,
    FarmaciaId    INT            NOT NULL,
    Quantidade    INT            NOT NULL,
    Preco         DECIMAL(10,2)  NOT NULL DEFAULT 0,
    FOREIGN KEY (MedicamentoId) REFERENCES Medicamento(Id),
    FOREIGN KEY (FarmaciaId)    REFERENCES Farmacia(Id)
);

-- ===========================
-- Tabela: Reserva
-- ===========================
CREATE TABLE Reserva (
    Id           INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FarmaciaId   INT            NOT NULL,
    NomeCliente  NVARCHAR(100)  NOT NULL,
    DataReserva  DATETIME       NULL DEFAULT GETDATE(),
    Estado       NVARCHAR(50)   NULL,
    FOREIGN KEY (FarmaciaId) REFERENCES Farmacia(Id)
);

-- ===========================
-- Tabela: ReservaProduto
-- ===========================
CREATE TABLE ReservaProduto (
    Id         INT  IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ReservaId  INT  NOT NULL,
    StockId    INT  NOT NULL,
    Quantidade INT  NOT NULL,
    FOREIGN KEY (ReservaId) REFERENCES Reserva(Id),
    FOREIGN KEY (StockId)   REFERENCES Stock(Id)
);

-- ===========================
-- Tabela: Venda
-- ===========================
CREATE TABLE Venda (
    Id         INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    DataVenda  DATETIME       NOT NULL DEFAULT GETDATE(),
    Tipo       NVARCHAR(20)   NOT NULL CHECK (Tipo IN ('encomenda', 'normal')),
    ValorTotal DECIMAL(10,2)  NOT NULL,
    Cliente    VARCHAR(100)   NOT NULL,
    FarmaciaId INT            NULL,
    FOREIGN KEY (FarmaciaId) REFERENCES Farmacia(Id)
);

-- ===========================
-- Tabela: VendaProduto
-- ===========================
CREATE TABLE VendaProduto (
    Id            INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    VendaId       INT            NOT NULL,
    MedicamentoId INT            NOT NULL,
    Quantidade    INT            NOT NULL CHECK (Quantidade > 0),
    PrecoUnitario DECIMAL(10,2)  NOT NULL,
    Subtotal      DECIMAL(10,2)  NOT NULL,
    FOREIGN KEY (VendaId)       REFERENCES Venda(Id),
    FOREIGN KEY (MedicamentoId) REFERENCES Medicamento(Id)
);
