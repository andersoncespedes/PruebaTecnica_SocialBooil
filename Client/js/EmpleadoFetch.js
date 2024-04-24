export async function GetAll(){
    const data = await fetch("http://localhost:5229/api/empleado");
    return await data.json();
}