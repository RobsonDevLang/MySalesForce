import "./TableComponent.css";

export default function TableComponent(props: any) {
  const { headers, data } = props;
  return (
    <table className="custom-table">
      <thead>
        <tr>
          {headers.map((header: string, index: number) => (
            <th key={index}>{header}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {data.map((row: any[], rowIndex: number) => (
          <tr key={rowIndex}>
            {row.map((cell: any, cellIndex: number) => (
              <td key={cellIndex}>{cell}</td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}
