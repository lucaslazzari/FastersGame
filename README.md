# FASTERSGAME
Aplicação Console FastersGame Projeto Netuno utilizando .Net 6, Arquitetura Limpa, Padrão Repository, Dapper e Banco de Dados SqlServer

# DESAFIO NETUNO
TELA DE CADASTRO
1) Nome completo
2) Data de nascimento (Deve ter no mínimo 18 anos)
3) Email
4) Senha 
5) Confirmar senha (As senhas devem ser validadas e devem ser iguais)
6) Salvar
7) Direciona para a tela de login

TELA DE LOGIN
1) Solicita Email e senha
2) Valida
3) Caso esteja correta redireciona para a tela do jogo
4) Caso não, informe o erro ao usuário e tente novamente (Se errar a senha 3 vezes encerra o 
programa)

TELA DO JOGO
Escolha a classe para jogar:
1) Paladino [lança e escudo]
2) Atirador [Arma]
3) Guerreiro [Espada e Escudo]
4) Bárbaro [Machado ou Marreta]
4) Arqueiro [Arco]
5) Cadastre as características físicas do seu avatar, forneça as opções (Cor de cabelo, de pele etc....)
6) A diferença de customização está nas ferramentas de batalhas. 
6.1) O paladino escolhe ou a lança ou o escudo;
6.2) O atirador a Arma;
6.3) O Guerreiro a Espada e escudo; 
6.4) O bárbaro o machado ou a marreta 
6.5) O arqueiro o Arco
7) Escolher montaria (Forneça 5 opções de montaria para o usuário [Panda, Cavalo, etc])
8) Distribua pontos para cada atributo das classes e informe o usuário. Exemplo: Paladino Vida: 85, 
Mana: 35, Velocidade de Ataque: 1.25
9) Distribua pontos para cada atributo das Montarias e informe o usuário. Exemplo: Velocidade: 
3m/s, Tempo para descanso: 5 minutos
10) Printa na tela as informações da Classe escolhida, Ferramentas de batalha e montaria com 
todas as customizações que o usuário escolheu

# BANCO DE DADOS
<p>Criando tabela dos usuarios<p>
CREATE TABLE Users(
	IdUser int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FullName nvarchar(max) NOT NULL,
	Email nvarchar(max) NOT NULL,
	BirthDate nvarchar(8) NOT NULL,
	Passwords nvarchar(max) NOT NULL,
	IdPlayer int NOT NULL
)
	
 <p> ** Criando tabela das informaçoes do personagem de acordo com o usuario<p>
CREATE TABLE Player(
	IdPlayer int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdPlayerType int,
	IdMount int,
	IdFisicCharacteristics int
)

<p>Criando tabela do tipo do personagem<p>
CREATE TABLE PlayerType(
	IdPlayerType int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NameType nvarchar(max) NOT NULL,
	Weapon nvarchar(max) NOT NULL,
	Life int NOT NULL,
	Mana int NOT NULL,
	AtackSpeed float NOT NULL
)

<p>Criando tabela das caracteristicas fisicas<p>
CREATE TABLE FisicCharacteristics(
	IdFisicCharacteristics int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HairColor nvarchar(255) NOT NULL,
	SkinColor nvarchar(255) NOT NULL,
	EyeColor nvarchar(255) NOT NULL,
	Biotype nvarchar(255) NOT NULL
)

<p>Criando tabela da montaria<p>
CREATE TABLE Mount(
	IdMount int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MountName nvarchar(max) NOT NULL,
	MovimentSpeed int NOT NULL,
	RestTime int NOT NULL
)

<p>Alterando tabela Users para ter relacionamento com a tabela Player<p>
ALTER TABLE Users
   ADD CONSTRAINT fk_IdUserPlayer_IdPlayer FOREIGN KEY (IdPlayer)
      REFERENCES Player (IdPlayer)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

<p>Alterando tabela Player para ter relacionamento com a tabela FisicCharacteristics<p>
ALTER TABLE Player
   ADD CONSTRAINT fk_IdPlayerFisicCharacteristcs_IdFisicCharacteristics FOREIGN KEY (IdFisicCharacteristics)
      REFERENCES FisicCharacteristics (IdFisicCharacteristics)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

<p>Alterando tabela Player para ter relacionamento com a tabela Mount<p>
ALTER TABLE Player
   ADD CONSTRAINT fk_IdPlayerMount_IdMount FOREIGN KEY (IdMount)
      REFERENCES Mount (IdMount)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

<p>Alterando tabela Player para ter relacionamento com a tabela PlayerType<p>
ALTER TABLE Player
   ADD CONSTRAINT fk_IdPlayerType_IdPlayer FOREIGN KEY (IdPlayerType)
      REFERENCES PlayerType (IdPlayerType)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;
