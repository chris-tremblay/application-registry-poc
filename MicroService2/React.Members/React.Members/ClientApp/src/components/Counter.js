import React, { useEffect, useState } from 'react';
import PropTypes from "prop-types";

const Counter = (name) => {
  const [count, setCount] = useState(0);

  useEffect(() => {
    const customEvent = new CustomEvent("actualValue", {detail: count})
    window.dispatchEvent(customEvent);
  }, [count]);

  const onInc = () => {
    setCount(prev => prev + 1);
    const customEvent = new CustomEvent("incValue", {detail: count})
    window.dispatchEvent(customEvent);
  }

  const onDec = () => {
    setCount(prev => prev - 1);
    const customEvent = new CustomEvent("decValue", {detail: count})
    window.dispatchEvent(customEvent);
  }

  return <>
    <h2>Counter: <b>{count}</b></h2>
    <button onClick={onInc}>Increment</button>
    <button onClick={onDec}>Decrement</button>
  </>;
}

Counter.propTypes = {
  name: PropTypes.string.isRequired,
}

export default Counter