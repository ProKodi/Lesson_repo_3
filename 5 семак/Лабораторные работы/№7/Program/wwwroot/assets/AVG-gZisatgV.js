import{$ as a}from"./main-CpgxMhlz.js";a(()=>{a("#call_avg").on("click",async function(){let e=a("#name").val();if(typeof e!="string")
    {alert("Не верный тип данных");return}fetch("/AVGget",{method:"POST",body:new URLSearchParams({name:e})}).then(async t=>{if(!t.ok)throw new Error(await t.text());const o=await t.json();console.log("Имя:",o.AVG)}).catch(t=>{alert(`Ошибка при регистрации!. 
${t.message}`)})})});
