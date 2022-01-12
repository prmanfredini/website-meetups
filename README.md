to run application:

git clone > yarn install > yarn serve

# Meetups.API

API com acesso ao banco de dados de Meetups.

## Explicações

Segue trecho de esclarecimento sobre itens que vamos acrescentar na nossa Web API para acessar o banco de dados:

### Entidades

As entidades são essenciais e modelam como o banco de dados existe:

Nesse template as entidades já existem e podem ser encontradas [aqui](./Domain/Entity/).

### Classes de Request e Response

Por questão de boas práticas não expomos nossas classes de entidade para o mundo, por isso é necessário criar classes de entrada e saída dos nossos endpoints.

### Context

O Contexto é extremamente importante e através dele que conseguiremos acessar nosso banco de dados:

Nesse template o contexto já está criado e pode ser encontrado [aqui](./DAL/MeetupContext.cs).

### Swagger

O Swagger também está configurado e pode ser encontrado na URL: [https://localhost:7201/swagger](https://localhost:7201/swagger)

## Usando esse template no seu projeto

Caso deseje utilizar este template, basta seguir os seguintes passos:

1. Faça Download da atual [pasta](.) e coloque-a em seu projeto.

2. Garanta que sua string de conexão ao banco de dados esteja correta, você pode encontrá-la [aqui](./Startup.cs#L32).

3. Para ter acesso ao banco de dados, garanta a injeção do contexto da seguinte maneira:

```csharp
public class EventosService
{
    private readonly MeetupContext _context;

    public EventosService(MeetupContext context)
    {
        _context = context;
    }
}

```

4. Usando o campo `_context` você pode acessar suas tabelas:

```csharp
public Evento BuscaEvento(int id)
{
    return _context.Eventos.Find(id);
}
```

As tabelas são representadas pelas propriedades da classe do [MeetupContext](./DAL/MeetupContext.cs#L17).

Os métodos para realizar consultas nas nossas tabelas são os seguintes:

- Find: Busca um item na tabela: `_context.Eventos.Find(id)`;
- Where: Adiciona um filtro: `_context.Eventos.Where(evento => evento.IdEventoStatus == 1)`;

Os métodos para alterar nossas tabelas são os seguintes:

- Add: Adiciona Novo item na tabela: `_context.Add(eventoNovo)`;
- Remove: Remove o item do banco: `_context.Remove(eventoNovo)`;
- Para atualizar basta consultar sua entidade e alterar os campos necessários:

```csharp
var evento = _context.Eventos.Find(id);
// Atualizando campo do item
evento.IdEventoStatus = 2;

// Atualizando item 
_context.Eventos.Add(resultado).State = EntityState.Modified;
_context.SaveChanges();
```

PS: Lembrando que ao final das 3 operações (Criar, remover e atualizar) é necessário executar o método `SaveChanges`.

5. Por fim, crie suas classes de request e response para mapear o que será a entrada e a saída de nossos endpoints.
