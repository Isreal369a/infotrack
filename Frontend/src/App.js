import './App.css';
import { useState } from "react";
function App() {
  const [url, setUrl] = useState("");
  const [keyword, setKeyword] = useState("");
  const [message, setMessage] = useState("");


let handleSubmit = async (e) => {
  e.preventDefault();
  try {
    let response = await fetch(`https://localhost:5001/SearchEngineScrapper/GetResult?Url=${url}&Keyword=${keyword}` , {
      method: "GET",
      headers: {
        'Content-Type': 'application/json'        
      },   
    });
   
    let resJson = await response.json();
    if (response.status === 200) {
      setUrl("");
      setKeyword("");
      setMessage(resJson);
    } else {
      setMessage(resJson);
    }
  } catch (err) {
    console.log(err);
  }
};

return (
  <div className="App">
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        value={url}
        placeholder="url"
        onChange={(e) => setUrl(e.target.value)}
      />
      <input
        type="text"
        value={keyword}
        placeholder="keyword"
        onChange={(e) => setKeyword(e.target.value)}
      />
      
      <button type="submit">Search</button>

      <div className="message">{message ? <p>{message}</p> : null}</div>
    </form>
  </div>
);





}
export default App;
