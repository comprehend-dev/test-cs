import React from 'react';

interface AppProps {
    pluginName: string;
}

export function App({ pluginName }: AppProps): JSX.Element {
    return <div className="app">{pluginName}</div>;
}
