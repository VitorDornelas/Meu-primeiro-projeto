/*
 * Created by SharpDevelop.
 * User: dorne
 * Date: 09/06/2024
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TRABALHO_SA_APRESENTAÇÃO
{
	class Program
	{
		
		public static bool ValidaCPF(string cpf)
        {
        	// Var
        	string tempCpf,digito;
			int soma,i,resto;
			
			// Arrays com os multiplicadores para cálculo dos dígitos verificadores
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

				 // Verifica se o CPF tem exatamente 11 dígitos
	            if (cpf.Length != 11)
	                return false;

           
				 // Calcula a soma dos produtos dos 9 primeiros dígitos do CPF pelos respectivos multiplicadores
	            tempCpf = cpf.Substring(0, 9);
	            soma = 0;

		            for ( i = 0; i < 9; i++)
		                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
		            
					 // Calcula o resto da divisão da soma por 11
		             resto = soma % 11;
		            if (resto < 2)
		                resto = 0;
		            else
		                resto = 11 - resto;
            
			 		// Adiciona o primeiro dígito verificador ao final do tempCpf
		            digito = resto.ToString();
		            tempCpf = tempCpf + digito;
		            soma = 0;
		
		            for ( i = 0; i < 10; i++)
		                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
					
		            // Calcula o resto da divisão da soma por 11
		            resto = soma % 11;
		            
		            // Se o resto for menor que 2, o segundo dígito verificador é 0, caso contrário, é 11 menos o resto
		            if (resto < 2)
		                resto = 0;
		            else
		                resto = 11 - resto;
            
					// Adiciona o segundo dígito verificador ao final do tempCpf
		            digito = digito + resto.ToString();
		            
		 			 // Verifica se os dois dígitos verificadores calculados são iguais aos dois últimos dígitos do CPF original
		            return cpf.EndsWith(digito);
        }
		
		 // Propriedades estáticas para armazenar os dados do cliente
        public static int teleforne { get; set; }
        public static string Nome { get; set; }
        public static string Cpf { get; set; }
        public static string Email { get; set; }
        public static bool cadastroRealizado = false; // Variável para rastrear se o cadastro foi realizado
		
		public static void agendamento()
		{
		  
		    string data;
		    
		    Console.Clear();
		    // Mensagens para o usuário
            Console.WriteLine("AGENDAMENTO DE CONSULTA:");
		    Console.WriteLine("Digite uma data da consulta: ");
            data = Console.ReadLine();

            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Ola, "+Nome                                                                                                                                   );
            Console.WriteLine("Um dos nosso atendentes entrará em contato com você pelo " +teleforne+" em até 24 horas, para confirmação do agendamento para o dia "+data+".");
            Console.WriteLine("Obrigado!!                                                                                                                                   ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
          
			Console.ReadKey(true);
		}
		
		
		public static void menuPrincipal()
		{
			// Exibição do menu principal
			Console.WriteLine("=====================================");
			if (!cadastroRealizado)
			{
			Console.WriteLine("| 1. Cadrastro                       |");
			}
			Console.WriteLine("| 2. Orçamento                       |");
			Console.WriteLine("| 3. Dúvidas frequentes              |");
			Console.WriteLine("| 4. Fale Conosco                    |");
			Console.WriteLine("| 5. Sobre                           |");
			Console.WriteLine("| 6. Sair                            |");
			Console.WriteLine("=====================================");
		}
		
		public static void ConsultaMedicas()
		{
			Console.Clear();
			
			string[] nomes = new string[7];
            int[] valores = new int[7];
            int posicao,i, valorTotal = 0,resposta;
            bool continuar = true;

            // Inicialização dos nomes dos medicos e especialidade
            nomes[0] = "1. Dr. Ricardo Alves  | Clinico Geral  ";
            nomes[1] = "2. Dra. Ana Silva     | Cardiologista  ";
            nomes[2] = "3. Dr. Carlos Mendes  | Ginecologista  ";
            nomes[3] = "4. Dra. Sofia Costa   | Urologista     ";
            nomes[4] = "5. Dr. Eduardo Santos | pediatra       ";
            nomes[5] = "6. Dra. Laura Ferreira| ortopedista    ";
            nomes[6] = "7. Dr. André Oliveira | oftalmologista ";
          
            // Inicialização dos valores das consultas
            valores[0] = 100;
            valores[1] = 200;
            valores[2] = 150;
            valores[3] = 150;
            valores[4] = 130;
            valores[5] = 90;
            valores[6] = 120;

            
            while (continuar)
            {
                // Exibição do menu de consultas
                Console.WriteLine("CONSULTAR MEDICAS:");
	                for ( i = 0; i < nomes.Length; i++)
	                {
	                    Console.WriteLine( nomes[i] + "| R$" +valores[i]);
	                }
	            Console.WriteLine();
                Console.Write("Digite um número de 1 a 7 para escolher uma consultar: ");
                posicao = int.Parse(Console.ReadLine());

	                // Validação da posição escolhida
	                if (posicao < 1 || posicao > 7)
	                {
	                    Console.WriteLine("Número inválido, digite um valor entre 1 e 7");
	                }
		                else
		                {
		                	Console.WriteLine();
		                    // Adicionar o valor do procedimento escolhido ao total
		                    valorTotal += valores[posicao - 1];
		                    Console.WriteLine("Você escolheu:"+nomes[posicao - 1]+"com valor de R$"+ valores[posicao - 1]);
		                }
							Console.WriteLine();
				
                // Perguntar se o usuário quer continuar
                Console.Write("Deseja adicionar outro consultar? (1-sim/2-não):");
                continuar = Console.ReadLine().ToLower() == "1";
            }
	            // Exibir o valor total dos procedimentos escolhidos
	            Console.WriteLine("Valor total dos consultas escolhidas são: R$"+ valorTotal);
	      		Console.WriteLine();
	      		
				//Perguntar se o usuário deseja fazer um agendamento
				Console.WriteLine("Gostaria de fazer um agendamento?");
				Console.WriteLine("1-sim/2-não");
				resposta = int.Parse(Console.ReadLine());
				
					if(resposta == 1)
					{
						agendamento();
					
					}
			
		}
		
		public static void Checkup()
		{
			
			 // Declaração do vetor de checkup
            string[] checkup = new string[3];
            int posicao,resposta;

            Console.Clear();
            
		    Console.WriteLine("PACOTES DE CHECKUP");
            Console.WriteLine("----------------------------------------");
		    Console.WriteLine("1. Checkup Básico - R$ 400             |");
		    Console.WriteLine("                                       |");
		    Console.WriteLine("   Consulta Médica Geral               |");
		    Console.WriteLine("   Exame de Sangue                     |");
		    Console.WriteLine("   Exame de Fezes                      |");
		    Console.WriteLine("   Exame de Urina                      |");
		    Console.WriteLine("----------------------------------------");
		   
			Console.WriteLine("----------------------------------------");
		    Console.WriteLine("2. Checkup Completo - R$ 600           |");
		    Console.WriteLine("                                       |");
		    Console.WriteLine("   Consulta Médica Geral               |");
		    Console.WriteLine("   Exame de Sangue                     |");
		    Console.WriteLine("   Exame de Fezes                      |");
		    Console.WriteLine("   Exame de Urina                      |");
		    Console.WriteLine("   Hemograma Completo                  |");
		    Console.WriteLine("   Eletrocardiograma                   |");
		    Console.WriteLine("   Audiometria                         |");
		    Console.WriteLine("----------------------------------------");
		    
		    Console.WriteLine("----------------------------------------");
		    Console.WriteLine("3. Checkup Avançado - R$ 1000          |");
		    Console.WriteLine("                                       |");
		    Console.WriteLine("   Consulta Médica Geral               |");
		    Console.WriteLine("   Exame de Sangue                     |");
		    Console.WriteLine("   Exame de Fezes                      |");
		    Console.WriteLine("   Exame de Urina                      |");
			Console.WriteLine("   Hemograma Completo                  |");
		    Console.WriteLine("   Eletrocardiograma                   |");
		    Console.WriteLine("   Audiometria                         |");
		    Console.WriteLine("   Exame de Visão                      |");
		    Console.WriteLine("   Teste Ergométrico                   |");
		    Console.WriteLine("   Radiografia de Tórax                |");
		    Console.WriteLine("----------------------------------------"); 
			
		    // Pergunta ao usuário se deseja fazer um agendamento
			Console.WriteLine("Gostaria de fazer um agendamento?");
			Console.WriteLine("(1-sim/2-não)");
			resposta = int.Parse(Console.ReadLine());
			
			if(resposta == 1)
			{
            // Inicialização do vetor de checkup
           		checkup[0]= "1. Checkup Básico - R$ 400";
				checkup[1]= "2. Checkup Completo - R$ 600";
				checkup[2]= "3. Checkup Avançado - R$ 1000";
            
	            // Solicitação ao usuário para inserir um número
	            Console.Write("Digite um número de 1 a 3 para escolher um Checkup: ");
	            posicao = int.Parse(Console.ReadLine());

                // Exibição do nome correspondente à posição escolhida
                Console.WriteLine("Você escolheu {0} é: ({1}",posicao,checkup [posicao - 1]+")");
                Console.ReadKey(true);
                
                agendamento();
			}

										            	
		}
		public static void Orçamento()
		{	
			Console.Clear();
			// Exibição do menu de orçamento
			Console.WriteLine("=====================================");
			Console.WriteLine("| 1. Checkup                         |");
			Console.WriteLine("| 2. Consulta médica                 |");
			Console.WriteLine("| 0. Voltar                          |");
			Console.WriteLine("=====================================");
		}
        
		
		public static void Main(string[] args)
		{
			 //var
			int opMenuP,dados,oporçamento;
			
			
			// Mensagem de boas-vindas
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
			Console.WriteLine("|                                Seja bem-vindo á clinica Saúde e bem estar!!!                                                    |");
			Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------"); 
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("");
				
			
			Console.ReadKey(true);
			Console.Clear();
			
			do {
					// Carregando o menu principal
					menuPrincipal();
					Console.Write("Digite uma opção: ");
					opMenuP = int.Parse(Console.ReadLine());
				
					Console.Clear();
				
					switch (opMenuP)
					{
						case 1:
							do{

                                    Console.WriteLine("CADASTRO CLIENTE");

                                    // Entrada de dados

                                        // ClienteID
                                        Console.Write("Nome:");
                                        Nome = (Console.ReadLine());

                                        // TELEFORNE
                                        Console.Write("Teleforne:");
                                        teleforne =int.Parse(Console.ReadLine());

                                        // CPF
                                         bool cpfValido;
			                                do
			                                {
			                                    Console.Write("CPF: ");
			                                    Cpf = Console.ReadLine();
			                                    cpfValido = ValidaCPF(Cpf);
			                                    if (!cpfValido)
			                                    {
			                                        Console.WriteLine("CPF inválido! Tente novamente.");
			                                    }
			                                   
			                                } while (!cpfValido);

                                        // E-mail
                                        Console.Write("E-mail:");
                                        Email = Console.ReadLine();
                                        
                                        cadastroRealizado = true; // Marca o cadastro como realizado
                                        
                                        Console.Clear();
                                        
                                    Console.WriteLine("-------------------------------------");
                                    Console.WriteLine("|        RELATÓRIO CLIENTE          |");
                                    Console.WriteLine("-------------------------------------");

                                    // Saida de dados                                    

                                        // ClienteID

                                   Console.WriteLine("NOME: "+Nome);
                                   Console.WriteLine("TELEFORNE: "+teleforne);
                                   Console.WriteLine("CPF: "+Cpf);
                                   Console.WriteLine("E-MAIL: "+Email);
                                   
                                   Console.WriteLine();
									
									//Verificação se os dados estão corretos
		                            Console.WriteLine("Seus estão corretos (1. sim / 2. não)");
		                            dados = int.Parse(Console.ReadLine());
		                            Console.Clear();
							   } while (dados != 1);
					     	break;
							
						
						case 2:
							do{
								// Carregando o menu orçamento
									Orçamento();
									Console.Write("Digite uma opção: ");
									oporçamento = int.Parse(Console.ReadLine());
								
									switch (oporçamento) 
									{	
										case 1:// Carregando Pacotes de Checkup
											Checkup();
											break;
										case 2:// Carregando Consultas Médicas
											ConsultaMedicas();
											break;
										default:
											Console.Clear();
											break;
											
								  }// fim do switch do menu orçamento
									} while (oporçamento != 0);// Fim do menu orçamento
							break;
							
						case 3:// Dúvidas frequentes
								Console.Clear();
								Console.WriteLine("DUVIDAS FREQUENTES");
								Console.WriteLine();
								Console.WriteLine("ENDEREÇO:");
							    Console.WriteLine("Fenda do biquine,Rua Sei Lá Onde, nº 666.");
								Console.WriteLine();
								Console.WriteLine("QUAL O HORÁRIO DE FUNCIONAMANTO?");
							    Console.WriteLine("Estamos abertos de segunda a sexta-feira, das 8h às 18h.");
							    Console.WriteLine();
							    Console.WriteLine("QUAIS SÃO OS PROCEDIMENTOS OFERECIDOS?");
							    Console.WriteLine("Oferecemos consultas, exames laboratoriais,e diversos pacotes de checkup.");
							    Console.WriteLine();
							    Console.WriteLine("QUAIS SÃO AS FORMAS DE PAGAMENTOS ACEITAS?");
							    Console.WriteLine("Aceitamos pagamentos em dinheiro, cartões de crédito e débito, e planos de saúde conveniados.");
							    Console.WriteLine();
							    Console.WriteLine("O QUE DEVO TRAZER NO DIA DA CONSULTA?");
							    Console.WriteLine("Por favor, traga um documento de identidade com foto, seu cartão do plano de saúde (se aplicável) e os exames anteriores, se houver.");
							    Console.WriteLine();
					            Console.WriteLine("0. volta");
					            Console.ReadKey();
					            Console.Clear();
							break;
						case 4:// Fale Conosco
								
								Console.Clear();
					            Console.WriteLine("FALE CONOSCO");
					            Console.WriteLine();
					            Console.WriteLine("TELEFORNE");
					            Console.WriteLine("(31)4002-8922 / (31)1234-5678");
					            Console.WriteLine();
					            Console.WriteLine("E-MAIL");
					            Console.WriteLine("clinicasaudebemestar@gmail.com");
					            Console.WriteLine();
					            Console.WriteLine("0. volta");
					            Console.ReadKey();
					            Console.Clear();
							break;
						case 5: // Sobre
							
								Console.Clear();
								Console.WriteLine("Clínica SAÚDE E BEM ESTAR");
								Console.WriteLine();
								Console.WriteLine("NOSSA MISSÃO");
							    Console.WriteLine("Proporcionar cuidados de saúde de alta qualidade, promovendo o bem-estar de nossos pacientes.");
							    Console.WriteLine();
							    Console.WriteLine("NOSSA VISÃO");
							    Console.WriteLine("Ser a clínica de referência em cuidados médicos na região, reconhecida pela excelência e inovação.");
							    Console.WriteLine();
							    Console.WriteLine("NOSSOS VALORES");
							    Console.WriteLine("Compromisso com a saúde, ética, respeito, qualidade, e inovação.");
							    Console.WriteLine();
					            Console.WriteLine("0. volta");
					            Console.ReadKey();
					            Console.Clear();
							break;
						case 6:// Sair
							
							Console.Clear();
							Console.WriteLine("--------------------------------");
							Console.WriteLine("|  VOLTE SEMPLE!!              |");
							Console.WriteLine("--------------------------------");
							break;
						default:
							
							Console.WriteLine("Opção inválida!");
							break;
							
					}// fim do switch do menu principal
				
				} while (opMenuP != 6);// Fim do menu principal
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
		}
		
	}
}