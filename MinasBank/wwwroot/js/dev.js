chave = ''
function apagar(guid) {
    chave = guid
    confirmar('Tem certeza?', excluir)
}
   
function excluir() {
    $.ajax("/api/Dev/" + chave, { method: "delete" })
        .then(function (response) {
            location.reload()
        })
}