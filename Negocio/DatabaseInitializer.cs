using Modelo.Cadastros;
using System.Linq;

namespace Negocio
{
    public static class DatabaseInitializer
    {

        public static void Initialize(ECommerceDeLivrosContext context)
        {

            var _context = context;

            if (!context.Assuntos.Any())
            {
                var assuntos = new Assunto[]
                {
                    new Assunto { ass_descricao = "Profissionais e Universitários" },
                    new Assunto { ass_descricao = "Universitários Técnicos e Profissionais" },
                    new Assunto { ass_descricao = "Fantasia, Horror e Ficção Científica" },
                    new Assunto { ass_descricao = "Administração de Negócios" },
                    new Assunto { ass_descricao = "Ciências" },
                };
                foreach (Assunto assunto in assuntos)
                {
                    context.Assuntos.Add(assunto);
                }
            }
            if (!context.Categorias.Any())
            {
                var categorias = new Categoria[]
                {
                    new Categoria { cat_nome="Autoajuda" }, new Categoria { cat_nome="Administração" },
                    new Categoria { cat_nome="Negócios" }, new Categoria { cat_nome="Economia" },
                    new Categoria { cat_nome="Literatura e Ficção" }, new Categoria { cat_nome="Gestão e Liderança" },
                    new Categoria { cat_nome="Engenharia" }, new Categoria { cat_nome="Política" },
                    new Categoria { cat_nome="Filosofia" }, new Categoria { cat_nome="Ciências Sociais" },
                    new Categoria { cat_nome="Computação" }, new Categoria { cat_nome="Informática" },
                    new Categoria { cat_nome="Psicologia e Aconselhamento" }, new Categoria { cat_nome="Universitários" },
                    new Categoria { cat_nome="Fantasia" }, new Categoria { cat_nome="Horror" },
                    new Categoria { cat_nome="Ficção Científica" }, new Categoria { cat_nome="Ciências" },
                    new Categoria { cat_nome="Matemática" }, new Categoria { cat_nome="Programação" },
                    new Categoria { cat_nome="Literatura e Ficção" },new Categoria { cat_nome="Educação" },
                    new Categoria { cat_nome="Física" },
                };
                foreach (Categoria categoria in categorias)
                {
                    context.Categorias.Add(categoria);
                }
            }
            if (!context.Categorias_Ativacao.Any())
            {
                var categoriasAtivacao = new CategoriaAtivacao[]
                {
                    new CategoriaAtivacao { cata_descricao = "Voltou ao Mercado" },
                    new CategoriaAtivacao { cata_descricao = "Liberado pelo Administrador" }
                };
                foreach (CategoriaAtivacao catAtivacao in categoriasAtivacao)
                {
                    context.Categorias_Ativacao.Add(catAtivacao);
                }
            }
            if (!context.Categorias_Inativacaos.Any())
            {
                var categoriasInativacao = new CategoriaInativacao[]
                {
                    new CategoriaInativacao { cati_descricao = "Fora do Mercado" },
                    new CategoriaInativacao { cati_descricao = "Abaixo da Precificação Base" }
                };
                foreach (CategoriaInativacao catInativacao in categoriasInativacao)
                {
                    context.Categorias_Inativacaos.Add(catInativacao);
                }
            }
            if (!context.Precificacoes.Any())
            {
                var precificacoes = new Precificacao[]
                {
                    new Precificacao { pre_porcentagem = 1.3, pre_nome = "30%" },
                    new Precificacao { pre_porcentagem = 1.2, pre_nome = "20%" },
                    new Precificacao { pre_porcentagem = 1.1, pre_nome = "10%" },
                };
                foreach (Precificacao precificacao in precificacoes)
                {
                    context.Precificacoes.Add(precificacao);
                }
            }
            if (!context.Autores.Any())
            {
                var autores = new Autor[]
                {
                    new Autor { aut_nome="Walter Riso" }, new Autor { aut_nome="John C. Maxwell" },
                    new Autor { aut_nome="Gary Keller" }, new Autor { aut_nome="Eduardo Ferraz" },
                    new Autor { aut_nome="Matt Kingdon" }, new Autor { aut_nome="Nicholas Carr" },
                    new Autor { aut_nome="Susan J. Fowler" }, new Autor { aut_nome="Eric Ries" },
                    new Autor { aut_nome="Daniel Goleman" }, new Autor { aut_nome="Stone Brad" },
                    new Autor { aut_nome="Ashlee Vance" }, new Autor { aut_nome="Viktor Mayer-Schonberger" },
                    new Autor { aut_nome="William Gibson" }, new Autor { aut_nome="Carol Dweck " },
                    new Autor { aut_nome="Tiago Mattos" }, new Autor { aut_nome="David L. Rogers" },
                    new Autor { aut_nome="Dan Harris " }, new Autor { aut_nome="Darrell Huff" },
                    new Autor { aut_nome="Peter Schiff" }, new Autor { aut_nome="Shelley Powers" },
                    new Autor { aut_nome="Lueders Anderson" }, new Autor { aut_nome="Benjamin Graham" },
                    new Autor { aut_nome="Tony Crilly" }, new Autor { aut_nome="David Salsburg" },
                    new Autor { aut_nome="John W. Foreman" }, new Autor { aut_nome="Provost Foster" },
                    new Autor { aut_nome="J. R. R. Tolkien" }, new Autor { aut_nome="Christopher Tolkien" },
                    new Autor { aut_nome="Raul Wazlawick" }, new Autor { aut_nome="Kenneth Reitz" },
                    new Autor { aut_nome="Joel Grus" }, new Autor { aut_nome="Luciano Ramalho" },
                    new Autor { aut_nome="Amaral Fernando" }, new Autor { aut_nome="Marijn Haverbeke" }
                };
                foreach (Autor autor in autores)
                {
                    context.Autores.Add(autor);
                }
            }
            
            if (!context.Editoras.Any())
            {
                var editoras = new Editora[]
                {
                    new Editora { edi_nome="Academia de Inteligência" }, new Editora { edi_nome="Vida Melhor" },
                    new Editora { edi_nome="Novo Século" }, new Editora { edi_nome="Editora Gente" },
                    new Editora { edi_nome="DVS Editora" }, new Editora { edi_nome="Vintage Digital" },
                    new Editora { edi_nome="Bei" }, new Editora { edi_nome="Novatec" },
                    new Editora { edi_nome="LeYa" }, new Editora { edi_nome="Objetiva" },
                    new Editora { edi_nome="Intrínseca" }, new Editora { edi_nome="Elsevier" },
                    new Editora { edi_nome="Aleph" }, new Editora { edi_nome="BelasLetras" },
                    new Editora { edi_nome="Autêntica Business" }, new Editora { edi_nome="Sextante" },
                    new Editora { edi_nome="Alta Books" }, new Editora { edi_nome="HarperCollins" },
                    new Editora { edi_nome="Planeta" }, new Editora { edi_nome="Zahar" },
                    new Editora { edi_nome="WMF Martins Fontes" }, new Editora { edi_nome="No Starch Press" },
                    new Editora { edi_nome="Crítica" },
                };
                foreach (Editora editora in editoras)
                {
                    context.Editoras.Add(editora);
                }
            }
            if (!context.Fornecedores.Any())
            {
                var fornecedores = new Fornecedor[]
                {
                    new Fornecedor { for_nome="Amazon", for_cnpj="93546228000162" },
                    new Fornecedor { for_nome="Saraiva", for_cnpj="20819557000166" },
                    new Fornecedor { for_nome="Livraria Cultura", for_cnpj="78086733000188" },
                    new Fornecedor { for_nome="LER", for_cnpj="97071021000130" },
                    new Fornecedor { for_nome="Sollus", for_cnpj="65076440000178" },
                    new Fornecedor { for_nome="Isto Distribuidora", for_cnpj="92717156000106" },
                    new Fornecedor { for_nome="Acaica Distribuidora", for_cnpj="86097452000159" },
                };
                foreach (Fornecedor fornecedor in fornecedores)
                {
                    context.Fornecedores.Add(fornecedor);
                }
            }
            if (!context.Generos.Any())
            {
                var generos = new Genero[]
                {
                    new Genero { gen_nome = "Masculino" },
                    new Genero { gen_nome = "Feminino" },
                    new Genero { gen_nome = "Outro" },
                };
                foreach (Genero genero in generos)
                {
                    context.Generos.Add(genero);
                }
            }
            if (!context.TipoDeLogradouro.Any())
            {
                var logradouros = new TipoDeLogradouro[]
                {
                    new TipoDeLogradouro { nome = "Avenida"},
                    new TipoDeLogradouro { nome = "Residencial"},
                    new TipoDeLogradouro { nome = "Rua"},
                    new TipoDeLogradouro { nome = "Campo"}
                };
                foreach (TipoDeLogradouro logradouro in logradouros)
                {
                    context.TipoDeLogradouro.Add(logradouro);
                }
            }
            if (!context.Paises.Any())
            {
                var paises = new Pais[]
                {
                    new Pais { pai_nome = "Afeganistão" }, new Pais { pai_nome = "África do Sul" }, new Pais { pai_nome = "Akrotiri" }, new Pais { pai_nome = "Albânia" }, new Pais { pai_nome = "Alemanha" }, new Pais { pai_nome = "Andorra" }, new Pais { pai_nome = "Angola" }, new Pais { pai_nome = "Anguila" }, new Pais { pai_nome = "Antárctida" }, new Pais { pai_nome = "Antígua e Barbuda" }, new Pais { pai_nome = "Arábia Saudita" }, new Pais { pai_nome = "Arctic Ocean" }, new Pais { pai_nome = "Argélia" }, new Pais { pai_nome = "Argentina" }, new Pais { pai_nome = "Arménia" }, new Pais { pai_nome = "Aruba" }, new Pais { pai_nome = "Ashmore and Cartier Islands" }, new Pais { pai_nome = "Atlantic Ocean" }, new Pais { pai_nome = "Austrália" }, new Pais { pai_nome = "Áustria" }, new Pais { pai_nome = "Azerbaijão" }, new Pais { pai_nome = "Baamas" }, new Pais { pai_nome = "Bangladeche" }, new Pais { pai_nome = "Barbados" }, new Pais { pai_nome = "Barém" }, new Pais { pai_nome = "Bélgica" }, new Pais { pai_nome = "Belize" }, new Pais { pai_nome = "Benim" }, new Pais { pai_nome = "Bermudas" }, new Pais { pai_nome = "Bielorrússia" }, new Pais { pai_nome = "Birmânia" }, new Pais { pai_nome = "Bolívia" }, new Pais { pai_nome = "Bósnia e Herzegovina" }, new Pais { pai_nome = "Botsuana" }, new Pais { pai_nome = "Brasil" }, new Pais { pai_nome = "Brunei" }, new Pais { pai_nome = "Bulgária" }, new Pais { pai_nome = "Burquina Faso" }, new Pais { pai_nome = "Burúndi" }, new Pais { pai_nome = "Butão" }, new Pais { pai_nome = "Cabo Verde" }, new Pais { pai_nome = "Camarões" }, new Pais { pai_nome = "Camboja" }, new Pais { pai_nome = "Canadá" }, new Pais { pai_nome = "Catar" }, new Pais { pai_nome = "Cazaquistão" }, new Pais { pai_nome = "Chade" }, new Pais { pai_nome = "Chile" }, new Pais { pai_nome = "China" }, new Pais { pai_nome = "Chipre" }, new Pais { pai_nome = "Clipperton Island" }, new Pais { pai_nome = "Colômbia" }, new Pais { pai_nome = "Comores" }, new Pais { pai_nome = "Congo-Brazzaville" }, new Pais { pai_nome = "Congo-Kinshasa" }, new Pais { pai_nome = "Coral Sea Islands" }, new Pais { pai_nome = "Coreia do Norte" }, new Pais { pai_nome = "Coreia do Sul" }, new Pais { pai_nome = "Costa do Marfim" }, new Pais { pai_nome = "Costa Rica" }, new Pais { pai_nome = "Croácia" }, new Pais { pai_nome = "Cuba" }, new Pais { pai_nome = "Curacao" }, new Pais { pai_nome = "Dhekelia" }, new Pais { pai_nome = "Dinamarca" }, new Pais { pai_nome = "Domínica" }, new Pais { pai_nome = "Egipto" }, new Pais { pai_nome = "Emiratos Árabes Unidos" }, new Pais { pai_nome = "Equador" }, new Pais { pai_nome = "Eritreia" }, new Pais { pai_nome = "Eslováquia" }, new Pais { pai_nome = "Eslovénia" }, new Pais { pai_nome = "Espanha" }, new Pais { pai_nome = "Estados Unidos" }, new Pais { pai_nome = "Estónia" }, new Pais { pai_nome = "Etiópia" }, new Pais { pai_nome = "Faroé" }, new Pais { pai_nome = "Fiji" }, new Pais { pai_nome = "Filipinas" }, new Pais { pai_nome = "Finlândia" }, new Pais { pai_nome = "França" }, new Pais { pai_nome = "Gabão" }, new Pais { pai_nome = "Gâmbia" }, new Pais { pai_nome = "Gana" }, new Pais { pai_nome = "Gaza Strip" }, new Pais { pai_nome = "Geórgia" }, new Pais { pai_nome = "Geórgia do Sul e Sandwich do Sul" }, new Pais { pai_nome = "Gibraltar" }, new Pais { pai_nome = "Granada" }, new Pais { pai_nome = "Grécia" }, new Pais { pai_nome = "Gronelândia" }, new Pais { pai_nome = "Guame" }, new Pais { pai_nome = "Guatemala" }, new Pais { pai_nome = "Guernsey" }, new Pais { pai_nome = "Guiana" }, new Pais { pai_nome = "Guiné" }, new Pais { pai_nome = "Guiné Equatorial" }, new Pais { pai_nome = "Guiné-Bissau" }, new Pais { pai_nome = "Haiti" }, new Pais { pai_nome = "Honduras" }, new Pais { pai_nome = "Hong Kong" }, new Pais { pai_nome = "Hungria" }, new Pais { pai_nome = "Iémen" }, new Pais { pai_nome = "Ilha Bouvet" }, new Pais { pai_nome = "Ilha do Natal" }, new Pais { pai_nome = "Ilha Norfolk" }, new Pais { pai_nome = "Ilhas Caimão" }, new Pais { pai_nome = "Ilhas Cook" }, new Pais { pai_nome = "Ilhas dos Cocos" }, new Pais { pai_nome = "Ilhas Falkland" }, new Pais { pai_nome = "Ilhas Heard e McDonald" }, new Pais { pai_nome = "Ilhas Marshall" }, new Pais { pai_nome = "Ilhas Salomão" }, new Pais { pai_nome = "Ilhas Turcas e Caicos" }, new Pais { pai_nome = "Ilhas Virgens Americanas" }, new Pais { pai_nome = "Ilhas Virgens Britânicas" }, new Pais { pai_nome = "Índia" }, new Pais { pai_nome = "Indian Ocean" }, new Pais { pai_nome = "Indonésia" }, new Pais { pai_nome = "Irão" }, new Pais { pai_nome = "Iraque" }, new Pais { pai_nome = "Irlanda" }, new Pais { pai_nome = "Islândia" }, new Pais { pai_nome = "Israel" }, new Pais { pai_nome = "Itália" }, new Pais { pai_nome = "Jamaica" }, new Pais { pai_nome = "Jan Mayen" }, new Pais { pai_nome = "Japão" }, new Pais { pai_nome = "Jersey" }, new Pais { pai_nome = "Jibuti" }, new Pais { pai_nome = "Jordânia" }, new Pais { pai_nome = "Kosovo" }, new Pais { pai_nome = "Kuwait" }, new Pais { pai_nome = "Laos" }, new Pais { pai_nome = "Lesoto" }, new Pais { pai_nome = "Letónia" }, new Pais { pai_nome = "Líbano" }, new Pais { pai_nome = "Libéria" }, new Pais { pai_nome = "Líbia" }, new Pais { pai_nome = "Listenstaine" }, new Pais { pai_nome = "Lituânia" }, new Pais { pai_nome = "Luxemburgo" }, new Pais { pai_nome = "Macau" }, new Pais { pai_nome = "Macedónia" }, new Pais { pai_nome = "Madagáscar" }, new Pais { pai_nome = "Malásia" }, new Pais { pai_nome = "Malávi" }, new Pais { pai_nome = "Maldivas" }, new Pais { pai_nome = "Mali" }, new Pais { pai_nome = "Malta" }, new Pais { pai_nome = "Man, Isle of" }, new Pais { pai_nome = "Marianas do Norte" }, new Pais { pai_nome = "Marrocos" }, new Pais { pai_nome = "Maurícia" }, new Pais { pai_nome = "Mauritânia" }, new Pais { pai_nome = "México" }, new Pais { pai_nome = "Micronésia" }, new Pais { pai_nome = "Moçambique" }, new Pais { pai_nome = "Moldávia" }, new Pais { pai_nome = "Mónaco" }, new Pais { pai_nome = "Mongólia" }, new Pais { pai_nome = "Monserrate" }, new Pais { pai_nome = "Montenegro" }, new Pais { pai_nome = "Mundo" }, new Pais { pai_nome = "Namíbia" }, new Pais { pai_nome = "Nauru" }, new Pais { pai_nome = "Navassa Island" }, new Pais { pai_nome = "Nepal" }, new Pais { pai_nome = "Nicarágua" }, new Pais { pai_nome = "Níger" }, new Pais { pai_nome = "Nigéria" }, new Pais { pai_nome = "Niue" }, new Pais { pai_nome = "Noruega" }, new Pais { pai_nome = "Nova Caledónia" }, new Pais { pai_nome = "Nova Zelândia" }, new Pais { pai_nome = "Omã" }, new Pais { pai_nome = "Pacific Ocean" }, new Pais { pai_nome = "Países Baixos" }, new Pais { pai_nome = "Palau" }, new Pais { pai_nome = "Panamá" }, new Pais { pai_nome = "Papua-Nova Guiné" }, new Pais { pai_nome = "Paquistão" }, new Pais { pai_nome = "Paracel Islands" }, new Pais { pai_nome = "Paraguai" }, new Pais { pai_nome = "Peru" }, new Pais { pai_nome = "Pitcairn" }, new Pais { pai_nome = "Polinésia Francesa" }, new Pais { pai_nome = "Polónia" }, new Pais { pai_nome = "Porto Rico" }, new Pais { pai_nome = "Portugal" }, new Pais { pai_nome = "Quénia" }, new Pais { pai_nome = "Quirguizistão" }, new Pais { pai_nome = "Quiribáti" }, new Pais { pai_nome = "Reino Unido" }, new Pais { pai_nome = "República Centro-Africana" }, new Pais { pai_nome = "República Checa" }, new Pais { pai_nome = "República Dominicana" }, new Pais { pai_nome = "Roménia" }, new Pais { pai_nome = "Ruanda" }, new Pais { pai_nome = "Rússia" }, new Pais { pai_nome = "Salvador" }, new Pais { pai_nome = "Samoa" }, new Pais { pai_nome = "Samoa Americana" }, new Pais { pai_nome = "Santa Helena" }, new Pais { pai_nome = "Santa Lúcia" }, new Pais { pai_nome = "São Bartolomeu" }, new Pais { pai_nome = "São Cristóvão e Neves" }, new Pais { pai_nome = "São Marinho" }, new Pais { pai_nome = "São Martinho" }, new Pais { pai_nome = "São Pedro e Miquelon" }, new Pais { pai_nome = "São Tomé e Príncipe" }, new Pais { pai_nome = "São Vicente e Granadinas" }, new Pais { pai_nome = "Sara Ocidental" }, new Pais { pai_nome = "Seicheles" }, new Pais { pai_nome = "Senegal" }, new Pais { pai_nome = "Serra Leoa" }, new Pais { pai_nome = "Sérvia" }, new Pais { pai_nome = "Singapura" }, new Pais { pai_nome = "Sint Maarten" }, new Pais { pai_nome = "Síria" }, new Pais { pai_nome = "Somália" }, new Pais { pai_nome = "Southern Ocean" }, new Pais { pai_nome = "Spratly Islands" }, new Pais { pai_nome = "Sri Lanca" }, new Pais { pai_nome = "Suazilândia" }, new Pais { pai_nome = "Sudão" }, new Pais { pai_nome = "Sudão do Sul" }, new Pais { pai_nome = "Suécia" }, new Pais { pai_nome = "Suíça" }, new Pais { pai_nome = "Suriname" }, new Pais { pai_nome = "Svalbard e Jan Mayen" }, new Pais { pai_nome = "Tailândia" }, new Pais { pai_nome = "Taiwan" }, new Pais { pai_nome = "Tajiquistão" }, new Pais { pai_nome = "Tanzânia" }, new Pais { pai_nome = "Território Britânico do Oceano Índico" }, new Pais { pai_nome = "Territórios Austrais Franceses" }, new Pais { pai_nome = "Timor Leste" }, new Pais { pai_nome = "Togo" }, new Pais { pai_nome = "Tokelau" }, new Pais { pai_nome = "Tonga" }, new Pais { pai_nome = "Trindade e Tobago" }, new Pais { pai_nome = "Tunísia" }, new Pais { pai_nome = "Turquemenistão" }, new Pais { pai_nome = "Turquia" }, new Pais { pai_nome = "Tuvalu" }, new Pais { pai_nome = "Ucrânia" }, new Pais { pai_nome = "Uganda" }, new Pais { pai_nome = "União Europeia" }, new Pais { pai_nome = "Uruguai" }, new Pais { pai_nome = "Usbequistão" }, new Pais { pai_nome = "Vanuatu" }, new Pais { pai_nome = "Vaticano" }, new Pais { pai_nome = "Venezuela" }, new Pais { pai_nome = "Vietname" }, new Pais { pai_nome = "Wake Island" }, new Pais { pai_nome = "Wallis e Futuna" }, new Pais { pai_nome = "West Bank" }, new Pais { pai_nome = "Zâmbia" }, new Pais { pai_nome = "Zimbabué" }
                };
                foreach(Pais pais in paises)
                {
                    context.Paises.Add(pais);
                }
            }
            if (!context.Estados.Any())
            {
                var estados = new Estado[]
                {
                    new Estado{ est_sigla = "Internacional" }, new Estado{ est_sigla = "AC" }, new Estado{ est_sigla = "AL" }, new Estado{ est_sigla = "AP" }, new Estado{ est_sigla = "AM" }, new Estado{ est_sigla = "BA" }, new Estado{ est_sigla = "CE" }, new Estado{ est_sigla = "DF" }, new Estado{ est_sigla = "ES" }, new Estado{ est_sigla = "GO" }, new Estado{ est_sigla = "MA" }, new Estado{ est_sigla = "MT" }, new Estado{ est_sigla = "MS" }, new Estado{ est_sigla = "MG" }, new Estado{ est_sigla = "PA" }, new Estado{ est_sigla = "PB" }, new Estado{ est_sigla = "PR" }, new Estado{ est_sigla = "PE" }, new Estado{ est_sigla = "PI" }, new Estado{ est_sigla = "RJ" }, new Estado{ est_sigla = "RN" }, new Estado{ est_sigla = "RS" }, new Estado{ est_sigla = "RO" }, new Estado{ est_sigla = "RR" }, new Estado{ est_sigla = "SC" }, new Estado{ est_sigla = "SP" }, new Estado{ est_sigla = "SE" }, new Estado{ est_sigla = "TO" }
                };
                foreach(Estado estado in estados)
                {
                    context.Estados.Add(estado);
                }
            }
            if (!context.Bandeiras.Any())
            {
                var bandeiras = new Bandeira[]
                {
                    new Bandeira { ban_nome = "Visa" },
                    new Bandeira { ban_nome = "Mastercard" },
                    new Bandeira { ban_nome = "Elo" },
                };
                foreach(Bandeira bandeira in bandeiras)
                {
                    context.Bandeiras.Add(bandeira);
                }
            }
            if (!context.StatusPedido.Any())
            {
                var statusPedido = new StatusPedido[]
                {
                    new StatusPedido { sta_ped_descricao = "Carrinho" },
                    new StatusPedido { sta_ped_descricao = "Em Processamento" },
                    new StatusPedido { sta_ped_descricao = "Em Trânsito" },
                    new StatusPedido { sta_ped_descricao = "Entregue" },
                    new StatusPedido { sta_ped_descricao = "Aprovada" },
                    new StatusPedido { sta_ped_descricao = "Reprovada" },
                    new StatusPedido { sta_ped_descricao = "Em Troca" },
                    new StatusPedido { sta_ped_descricao = "Troca Autorizada" },
                    new StatusPedido { sta_ped_descricao = "Troca Reprovada" },
                    new StatusPedido { sta_ped_descricao = "Troca Recebida" },
                    new StatusPedido { sta_ped_descricao = "Troca Finalizada" },
                };
                foreach(StatusPedido status in statusPedido)
                {
                    context.StatusPedido.Add(status);
                }
            }

            context.SaveChanges();

        }
    }
}
