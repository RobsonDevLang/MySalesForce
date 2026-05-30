## Convenção de commits

Formato:
`tipo(escopo-opcional): descrição`

### Tipos permitidos
- `feat`: nova funcionalidade
- `fix`: correção de bug
- `docs`: documentação
- `style`: ajustes visuais/formatação sem alterar lógica
- `refactor`: refatoração sem mudança de regra de negócio
- `test`: criação ou ajuste de testes
- `chore`: tarefas técnicas e manutenção
- `ci`: ajustes de pipeline/integração contínua
- `build`: mudanças de build, dependências ou empacotamento
- `perf`: melhoria de performance
- `revert`: reversão de commit

## Regra de merge
- Utilizar `Squash and merge`
- O título do PR deve virar o commit final na `main`
- O commit final deve seguir a convenção de commits