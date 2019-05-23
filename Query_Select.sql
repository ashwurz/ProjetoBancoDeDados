select Produtos_Finalizados.Sequencia_Producao, Produtos.Nome, Materia_Prima.Nome, Materia_Prima.Custo, Produtos.Lucro_Producao, Produtos_Finalizados.Data_Producao 
from Produtos_Finalizados join Produtos on Produtos_Finalizados.Nome  = Produtos.Nome 
join Materia_Prima on Produtos.Nome_Materia_Principal = Materia_Prima.Nome